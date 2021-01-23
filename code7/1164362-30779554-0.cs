    private string Password = "login"
    private void button14_Click(object sender, EventArgs e) // Main Screen Password Login Button
    {
  
        if (textBox1.Text == PassWord)
        {
            Password = textBox3.Text;
            // textBox1.Clear();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = false;
            button16.Enabled = true;
            button16.Visible = true;
            button20.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
    
            button14.Click += ResetTimer;
        }
    
        else
        {
            MessageBox.Show("Password is Incorrect");
            textBox1.Clear();
        }
    }
    
    private void button17_Click(object sender, EventArgs e) // Admin Update New password Button
    {
    
        if(textBox3.Text == textBox4.Text)
        {
            Password = textBox3.Text; // update the class variable Password to be the new password
            MessageBox.Show("Password Changed");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox3.Enabled = false;
            textBox4.Enabled = false;
    
        }
        else
        {
            MessageBox.Show("Password Does Not Match");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        button17.Click += ResetTimer;
    }
