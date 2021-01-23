                public override void OnActionExecuting(HttpActionContext actionContext)
                {
                        bool isAuthenticated = IsAuthenticated(actionContext);
        
                        if (!isAuthenticated)
                        {
                            actionContext.Response = actionExecutedContext.Request.CreateResponse<CustomActionResult>(HttpStatusCode.Unauthorized, new CustomActionResult
                            {
                                Message = "... insert error message here ...",
                                Details = null
                            });
                        }
                    }
                }
        
                public class CustomActionResult
                {
                    public string Message { get; set; }
                    public string Details { get; set; }
                }
