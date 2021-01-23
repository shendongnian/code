                 var returnedToken = (TokenResponse)result.ReturnedObject;
                    var ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, ConvertUnitToDateTime(returnedToken.expires_in), true, returnedToken.access_token);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie)
