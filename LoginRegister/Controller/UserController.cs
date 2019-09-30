using LoginRegister.Context;
using LoginRegister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginRegister.Controller
{
    public class UserController
    {
        public void AddUser(string uname, string pword)
        {
            var result = 0;
            User user = new User();
            MyContext _context = new MyContext();

            user.Username = uname;
            user.Password = pword;
            _context.Users.Add(user);
            result = _context.SaveChanges();

            if (result > 0)
            {
                MessageBox.Show("Register Successful!");
            }
            else
            {
                MessageBox.Show("Register Failed!");
            }
        }

        public bool UserLogin(string uname, string pword)
        {
            var status = true;
            User user = new Model.User();
            MyContext _context = new MyContext();

            var get = _context.Users.Where(u => u.Username == uname).FirstOrDefault<User>();

            if (get == null)
            {
                MessageBox.Show("You are not Registered yet!");
                status = false;
            }
            else
            {
                if (get.Password != pword)
                {
                    MessageBox.Show("Your Password is Incorrect!");
                    status = false;
                }
                else
                {
                    MessageBox.Show("Login Successful!");
        
                    //MainWindow main = new MainWindow();
                    //main.Hide();
                    //Home home = new Home();
                    //home.Show();
                }
                
            }
            return status;
        }

        public void ChangePass(string uname, string pword)
        {
            var result = 0;

            User user = new User();
            MyContext _context = new MyContext();

            var get = _context.Users.Where(u => u.Username == uname).FirstOrDefault<User>();

            if (get == null)
            {
                MessageBox.Show("Your Username is Incorrect!");
            }
            else
            {
                if (get.Password != pword)
                {
                    get.Password = pword;
                    result = _context.SaveChanges();

                    if (result > 0)
                    {
                        MessageBox.Show("Update Success!");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Your Password can't be the same!");
                }
            }
        }
    }
}
