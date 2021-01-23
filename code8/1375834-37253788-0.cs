    HttpCookie cookie = Request.Cookies.Get("Location");
    if (cookie != null)
    {
        string cookieString = cookie["Location"].ToString();
        switch (cookieString)
        {
            case "":
            case "-- Europe and Eastern Europe --":
            case "-- Asia & South-East Asia --":
            case "-- North & South of America --":
                Response.Redirect("Index.aspx");
                break;
            default:
                Response.Redirect(string.Format("Berava.aspx?Country={0}", cookie.Value));
                break;
        }
    }
    else
    {
        //this is the null case...
        Response.Redirect("Index.aspx");
    }
