        public class PatientAuthorizeAttribute : TypeFilterAttribute
        {
        public PatientAuthorizeAttribute(params PatientAccessRights[] right) : base(typeof(AuthFilter)) //PatientAccessRights is an enum
        {
            Arguments = new object[] { right };
        }
        private class AuthFilter : IActionFilter
        {
            PatientAccessRights[] right;
            IAuthService authService;
            public AuthFilter(IAuthService authService, PatientAccessRights[] right)
            {
                this.right = right;
                this.authService = authService;
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var allparameters = context.ActionArguments.Values;
                if (allparameters.Count() == 1)
                {
                    var param = allparameters.First();
                    if (typeof(IPatientRequest).IsAssignableFrom(param.GetType()))
                    {
                        IPatientRequest patientRequestInfo = (IPatientRequest)param;
                        PatientAccessRequest userAccessRequest = new PatientAccessRequest();
                        userAccessRequest.Rights = right;
                        userAccessRequest.MemberID = patientRequestInfo.PatientID;
                        var result = authService.CheckUserPatientAccess(userAccessRequest).Result; //this calls DB service to check from DB
                        if (result.Status == ReturnType.Failure)
                        {
                            //TODO: return apirepsonse
                            context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                        }
                    }
                    else
                    {
                        throw new AppSystemException("PatientAuthorizeAttribute not supported");
                    }
                }
                else
                {
                    throw new AppSystemException("PatientAuthorizeAttribute not supported");
                }
            }
        }
    }
