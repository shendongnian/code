    HttpCookie mycookie = Request.Cookies.Get("hello");
    if (mycookie == null)
    {
        mycookie = new HttpCookie("hello");
        mycookie["message"] = "Hello World";
        mycookie["ExpirationDate"] = DateTime.Now.AddMinutes(20).ToString();
        mycookie.Expires = DateTime.Now.AddMinutes(20);
        Response.Cookies.Add(mycookie);
        DateTime now = DateTime.Now;
        Response.Write("Cookie Not found <br> Time diff : ");
        Response.Write((mycookie.Expires - now).TotalMinutes);
    }
    else
    {
        DateTime end = Convert.ToDateTime(mycookie["ExpirationDate"]);
        DateTime now = DateTime.Now;
        Response.Write("Cookie found <br> Time diff : ");
        Response.Write((end-now).Minutes);
    }
