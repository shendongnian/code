    if (temp >= 1)//if there is any user we will get temp >= 1
    {
        //conn.Open(); //No need to open connection again
           
        //checkuser is SQL query so will never be equal to 
        //what user enters (like joe@example.com)
        //if (checkuser == TextBoxLogIn.Text)
        //{
        Session["New"] = TextBoxLogIn.Text;
        Response.Write("User name is correct");
        //}
    else //if no user with given name, temp will be 0
    {
        Response.Write("user does not exist");
        //}
        //conn.Close();
    }
    
