    //This class handles all the OwinMiddleware responses, so the name should 
    //not just focus on invalid authentication
    public class CustomAuthenticationMiddleware : OwinMiddleware
    {
        public CustomAuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);
            if (context.Response.StatusCode == 400 
                && context.Response.Headers.ContainsKey(
                          ServerGlobalVariables.OwinChallengeFlag))
            {
                var headerValues = context.Response.Headers.GetValues
                      (ServerGlobalVariables.OwinChallengeFlag);
                context.Response.StatusCode = 
                       Convert.ToInt16(headerValues.FirstOrDefault());
                context.Response.Headers.Remove(
                       ServerGlobalVariables.OwinChallengeFlag);
            }         
            
        }
    }
