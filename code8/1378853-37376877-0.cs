    public class MyAuthModule : IHttpModule
    {
        public void Dispose()
        {
            // Implement when you need to release unmanaged resources
        }
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Context_AuthenticateRequest;
            context.PostAuthenticateRequest += Context_PostAuthenticateRequest;
        }
        private void Context_AuthenticateRequest(object sender, EventArgs e)
        {
            // Call custom library to authenticate
            // and create a new ClaimsPrincipal with the info from the JSON object.
        }
        private void Context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // Optional: Inspect the ClaimsPrincipal and add more claims
        }
    }
