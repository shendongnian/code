        if (user != null && user.IsActive == true)
        {
            IdentityHelper.SignIn(manager, user, RememberMe.Checked);
            Response.Redirect("~/SecurePage.aspx"); //Redirect to a different page once user has logged in
        }
        else if(user != null && user.IsActive == false) 
        {
            FailureText.Text = "Sorry you no longer have access"; 
            ErrorMessage.Visible = true;
        }
        else
        {
            FailureText.Text = "Invalid username or password."; //This message displays even when user is not active
            ErrorMessage.Visible = true;
        }
