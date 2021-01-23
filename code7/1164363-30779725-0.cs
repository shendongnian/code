    // Move the password variable outside of the method scope,
    // so it can be used by all buttonXX_Click methods.
    private string password = "login";
    private void button14_Click(object sender, EventArgs e) // Main Screen Password Login Button
    {
        // No password variable defined here, instead we'll be using the one
        // we declared above.
        if (textBox1.Text == password)
        {
            // no changes here, omitted to make the answer shorter
        }
        else
        {
            MessageBox.Show("Password is Incorrect");
            textBox1.Clear();
        }
    }
    private void button19_Click(object sender, EventArgs e) // Admin Confirm Old Password Button
    {
        // no changes here, omitted to make answer shorter
    }
    private void button17_Click(object sender, EventArgs e) // Admin Update New password Button
    {
        if (textBox3.Text == textBox4.Text)
        {
            // By removing the local password variable and using the one
            // declared at the top, your change will be "remembered".
            password = textBox3.Text;
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
