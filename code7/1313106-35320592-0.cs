    string oldCookieVal = Request.Cookies["UserSettings"].Value;
            string sinput = searchInput.Text;
            if (Response.Cookies["UserSettings"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserSettings");
                cookie.Value = oldCookieVal + ":" + sinput;
                cookie.Expires = DateTime.Now.AddHours(3);
                Response.SetCookie(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserSettings");
                cookie.Value = sinput;
                cookie.Expires = DateTime.Now.AddHours(3);
                Response.SetCookie(cookie);
            }
