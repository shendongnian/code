    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = 403;
                        filterContext.Result = new JsonResult { Data = "LogOut" };
                    }
                    else {
                        filterContext.Result = new RedirectToRouteResult(
                                           new RouteValueDictionary
                                           {
                                           { "action", "Login" },
                                           { "controller", "Login" }
                                           });
                    }
