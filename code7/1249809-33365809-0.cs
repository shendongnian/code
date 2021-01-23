    if(user.IsActive == false)
    {
        FailureText.Text = "Sorry you no longer have access"; //This error message never displays
        ErrorMessage.Visible = true;
    }
    else
        Response.Redirect("~/SecurePage.aspx"); //Redirect to a different page once user has logged in
