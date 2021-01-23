    Response.Cookies["userName"].Value = "patrick";
    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
    
    HttpCookie aCookie = new HttpCookie("lastVisit");
    aCookie.Value = DateTime.Now.ToString();
    aCookie.Expires = DateTime.Now.AddDays(1);
    Response.Cookies.Add(aCookie);
