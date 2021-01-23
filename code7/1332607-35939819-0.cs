    var username = "abcd0";
    HttpCookie ck = new HttpCookie("mycookie");
    ck.Expires.AddDays(30);
    ck.Values.Add("username", username);
    Response.Cookies.Add(ck);
