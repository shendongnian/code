    private void registerButton_Click(object sender, EventArgs e)
    {
        //Check for password length           
        if (txtRegPass.Text.Length < 8)
        {
            MessageBox.Show("Password must be at least 8 characters long");
            txtRegPass.Focus();
            return;
        }
        //Check for other validations
        //...
        // don't forget to return; if it exists
        //If the code execution reaches here, it means all validation have been passed
        //So you can save data here.
    }
