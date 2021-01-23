    bool IsFormValid()
    {
        bool valid = !string.IsNullOrWhiteSpace(txtFirst.Value);
        if(!valid)
        {
            lblRFName.Text = "Please enter your first name";
            return false;
        }
        valid = !string.IsNullOrWhiteSpace(txtLast.Value);
        if(!valid)
        {
            lblRLName.Text = "Please enter your last name";
            return false;
        }
        // ...
        valid = !string.IsNullOrWhiteSpace(txtEmail.Value);
        if (!valid)
        {
            lblREmail.Text = "Please enter your email address";
            return false;
        }
        // ...
        return true;
    }
    public void btnRegister_Click(object sender, EventArgs e)
    {
        if (IsFormValid())
        {
            CreateNewUser();
            upReg.Update();
        }
    }
