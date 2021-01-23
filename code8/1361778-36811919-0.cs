    class ClassName
    {
        AuthenticationContext authenticationContext;
        private void initAuth()
        {
            // set authenticationContext
            authenticationContext = AuthFlow.InitAuthentication(appCredentials);
        }
        private void startAuth(string pin)
        {
            // use authenticationContext
        }
    }
