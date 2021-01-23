    HttpCookie loginCookie = new HttpCookie("LoginInfo");
    loginCookie["EmailID"] = txt_email.Text;
    //loginCookie.Domain = ConfigurationManager.AppSettings["SiteURL"]; //This one
    loginCookie.Expires = DateTime.Now.AddDays(30);
    loginCookie.Secure = false;
    //loginCookie.Domain = "/";  //and This one
    Response.Cookies.Add(loginCookie);
    Response.Redirect("home.aspx");
