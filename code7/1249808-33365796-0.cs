    if (user != null)
    {
         if (user.IsActive)
         {
             IdentityHelper.SignIn(manager, user, RememberMe.Checked);
             Response.Redirect("~/SecurePage.aspx"); //Redirect to a different page once user has logged in
         }
         else
         {
             FailureText.Text = "Sorry you no longer have access"; //This error message never displays
             ErrorMessage.Visible = true;
         }
    }
