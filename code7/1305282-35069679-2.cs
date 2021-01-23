    private void btnRegister_Click(object sender, EventArgs e)
    {
        var email = txtEmail.Text;
        var password = txtPassword.Text;
    
        var registration = new Registration { Email = email, Password = password }
    
        var bizService = new RegistrationService();
    
        var response = bizService.Register(registration);
    
        if(response.Success) Response.Redirect("~/registration/success");
    
        ltlError.Text = response.FailureMessage;
    
    }
