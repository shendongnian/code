                    int timeout = model.RememberMe ? 525600 : 30;
                    //DateTime timeout = model.RememberMe ? 525600 : 30;
                     string userData = JsonConvert.SerializeObject(model);
                     FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, login[0].adminUserName, DateTime.Now, DateTime.Now.AddMinutes(525600), false, userData);
                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                    Response.Cookies.Add(authcookie);
                  
                    
                return  Response.Redirect("~/Account/ChangePassword.aspx"); //authenticated area
                    
                }
                else
                {
                    Response.Write("Invalid UserID and Password");
                }
