    public void verification()
    {
                if (textBox1.Text == users[i].userName && textBox2.Text == users[i].password) //checks that the username and the password match. 
                {
                    MessageBox.Show("Your password is correct!");
                }
                else
                {
                    MessageBox.Show("Error. Your username or password are incorrect!");
                    attempts -= 1;
                }
                if(attempts == 0)
                {
                    Environment.Exit();
                }
    }
