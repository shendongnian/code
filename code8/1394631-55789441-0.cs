    HttpCookie cookie = Request.Cookies["MyCookie"];
    if (cookie!+null && !cookie.Value.IsEmpty())
    {
            // Update the cookie expiration
            cookie.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(1));
            Response.Cookies.Set(cookie);//Request.Cookies.Set(cookie);
    }
    else
    { 
    }
