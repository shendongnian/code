    private void button1_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textBox1.Text))
        {
            MessageBox.Show("Invalid password. Password cannot be empty.");
            return;
        }
        System.Text.RegularExpressions.Regex regex = null;
        regex = new System.Text.RegularExpressions.Regex("^([a-zA-Z0-9])*$");
        if (regex.IsMatch(textBox1.Text))
        {
            MessageBox.Show("Valid password.");
        }
        else
        {
            MessageBox.Show("Invalid password. Password cannot contain any special characters.");
        }
    }
