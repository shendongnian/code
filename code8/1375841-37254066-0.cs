            var cookie = Request.Cookies.Get("Location")?["Location"];
            switch (cookie)
            {
                case null:
                    Response.Redirect("Index.aspx");
                    // DO STUFF
                    break;
                case "":
                    // DO STUFF
                    break;
                case "-- Europe and Eastern Europe --":
                    // DO STUFF
                    break;
                case "-- Asia & South-East Asia --":
                    // DO STUFF
                    break;
                case "-- North & South of America --":
                    // DO STUFF
                    break;
                default:
                    Response.Redirect(string.Format("Berava.aspx?Country={0}", cookie.Value));
                    break;
            }
