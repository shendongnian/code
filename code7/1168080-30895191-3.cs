    if (Request.Cookies["user"] != null) // log in
    {
        logOut.Visible = false; // 2
    }
    else // log out 
    {
        logIn.Visible = false; // 2
        messages.Visible = false;
    }
