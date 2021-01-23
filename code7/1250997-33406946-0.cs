    if (context.HttpContext.Request.IsAjaxRequest())
                {
                    UrlHelper urlHelper = new UrlHelper(context.RequestContext);
                    context.HttpContext.Response.TrySkipIisCustomErrors = true;
                    context.HttpContext.Response.StatusCode = 403;
                    /* Get return url */
                    var returnUrl = context.RequestContext.HttpContext.Request.Url.PathAndQuery;
                    context.Result = new JsonResult
                        {
                            Data = new
                                {
                                    Error = "NotAuthorized",
                                    LogOnUrl = urlHelper.Action("LogIn", "Account", new {returnUrl})
                                },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                }
                else
                {
                    base.HandleUnauthorizedRequest(context);
                }
