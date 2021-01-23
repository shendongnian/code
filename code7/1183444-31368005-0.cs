    // textBox4 should be txtUserName for example, it's more intuitive
    var q = (from c in Session.DB.Guests
             where c.UserName == textBox4.Text
             select c).SingleOrDefault();
    if (q == null)
    {
        MessageBox.Show("UserName is Not Available");
    }
    else
    {
        if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null ||
            textBox4.Text == null || textBox5.Text == null || textBox6.Text == null)
        {
            MessageBox.Show("Empty Fields! All Fields Required!");
        }
        else
        {
            // textBox5 should be txtPassword and textBox6 should be txtConfirmPassword
            if (textBox5.Text.Contains(textBox4.Text) || textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Password Not match or contains username");
            }
            else
            {
                // textBox3 should be txtEmail, also you should try to find some existing Regex to validate your email
                if (!textBox3.Text.Contains("@") || !textBox3.Text.Contains("."))
                {
                    MessageBox.Show("Incorrect email address");
                }
                else
                {
                    Controller.UserController.RegisterUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                    MessageBox.Show("Register!");
                }
            }
        }
    }
