    [WebMethod]
    public static string LoginUser(string email, string pass)
    {
        //more code
        var ecookie= new HttpCookie("ecookie");
        ecookie["name"] = "roger";
        HttpContext.Current.Response.Cookies.Add(ecookie);
    }
