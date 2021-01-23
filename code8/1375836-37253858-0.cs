    HttpCookie cookie = Request.Cookies.Get("Location");
    
                if (cookie["Location"]==null)
                    Response.Redirect(string.Format("Berava.aspx?Country={0}", cookie.Value));
    else
                switch (cookie["Location"].ToString())
                {
                    case null:
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
