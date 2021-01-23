        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
            {
                base.HandleUnauthorizedRequest(actionContext);
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new ObjectContent(typeof(ErrorMessage),
                        new ErrorMessage()
                        {
                            StatusCode = (int)HttpStatusCode.Unauthorized,
                            Message = Constants.UnauthorisedErrorMessage,
                            ErrorCode = Constants.UnauthorisedErrorCode
                        }, new JsonMediaTypeFormatter())
                };
            }
