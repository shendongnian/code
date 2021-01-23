    User myuser = db.selectQuery("blah");
            if (data != null)
        {
            // assign the username, password, first and last name to the  session variables
            Session["first_name"] = myuser.first_name.ToString();
            Session["last_name"]  = myuser.last_name.ToString();
            Session["username"]   = myuser.username.ToString();
            Session["password"]   = myuser.password.ToString();
        }
