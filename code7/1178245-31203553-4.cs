    public void btnRegister_Click( ... )
    {
        var emailValidator = new RegexUtilities();
        bool validEmail = emailValidator.IsValidEmail( ..textbox-input.. );
        
        if (!validEmail)
        {
            txtError.Text = "Enter a valid email please";
            return;
        }
        //...
        //...
        //(Your submit code)
    }
