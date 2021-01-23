    string MailID = ConfigurationManager.AppSettings["MailId"];
    
    //Create a cookie
    HttpCookie mailCookie= new HttpCookie("mailCookie");
    
    //Add key-values in the cookie
    mailCookie.Values.Add("MailID", MailID);
    
    //set cookie expiry date-time. Keep it max value.
    mailCookie.Expires = DateTime.MaxValue;
    
    //Most important, write the cookie to client.
    Response.Cookies.Add(mailCookie);
    
    //Read the cookie from Request.
    HttpCookie mailCookie= Request.Cookies["mailCookie"];
    if (mailCookie== null)
    {
        //No cookie found or cookie expired.
        //Handle the situation here, Redirect the user or simply return;
    }
    //Cookie is found.
    if (!string.IsNullOrEmpty(mailCookie.Values["MailID"]))
    {
        string MailID= mailCookie.Values["MailID"].ToString();
    }
