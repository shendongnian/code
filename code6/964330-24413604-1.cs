    [HttpPost]
                public ActionResult Login(FormCollection form)
                {
                    bool success = WebSecurity.Login(form["username"], form["password"], false);
                    if (success)
                    {
                        var userId = WebSecurity.GetUserId(form["username"]);
                        string returnUrl = Request.QueryString["ReturnUrl"];
                        if (returnUrl == null)
                        {
                            Response.Redirect("~/home/index?userId=" + userId + "&userName=" + WebSecurity.currentUserName);
                        }
                        else
                        {
                            Response.Redirect(returnUrl);
                        }
                    }
                    return View();
                }
