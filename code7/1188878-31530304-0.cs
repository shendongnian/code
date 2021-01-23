    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                                    viewModel.Email,
                                                                    YOUR_ISSUE_DATE,
                                                                    YOUR_EXPIRE_DATE,
                                                                    viewModel.RememberMe,
                                                                    JsonConvert.SerializeObject(user),
                                                                    FormsAuthentication.FormsCookiePath);
    string hash = FormsAuthentication.Encrypt(ticket);
    HttpCookie authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
    Response.Cookies.Add(authcookie);
