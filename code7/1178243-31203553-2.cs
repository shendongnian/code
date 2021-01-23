    public void btnRegister_Click( ... )
    {
        bool validEmail = IsValidEmail( ..textbox-input.. );
        
        if (!validEmail)
        {
            txtError.Text = "Enter a valid email please";
            return;
        }
        //...
        //...
        //(Your submit code)
    }
