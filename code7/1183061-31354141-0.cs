    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserName.Text, DateTime.Now, DateTime.Now.AddMinutes(2880), false, role, FormsAuthentication.FormsCookiePath);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(UserName.Text, false));
