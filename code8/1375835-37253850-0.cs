     string coo = Convert.ToString(Request.Cookies["Location"]==null?null:Request.Cookies["Location"].Value);
                    switch(coo)
                    {
                        case null:
                            Response.Redirect("Index.aspx");
                        case "":
                            Response.Redirect("Index.aspx");
                        case "-- North & South of America --":
                             Response.Redirect("Index.aspx");
                        case "-- Asia & South-East Asia --":
                             Response.Redirect("Index.aspx");
                        case "-- Europe and Eastern Europe --":
                             Response.Redirect("Index.aspx");
                        default:
                            Response.Redirect(string.Format("Berava.aspx?Country={0}", coo)); 
    }
