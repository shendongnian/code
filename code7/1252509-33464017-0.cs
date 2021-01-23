    class PasswordAuthenticationHandler : AuthenticationHandler<PasswordAuthenticationOptions>
    {
        public PasswordAuthenticationHandler (PasswordAuthenticationOptionsoptions)
        {
            //set fields needed from options        
        }
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            //get the password out of the Request and create claims collection
            ...
            var claimsId = new ClaimsIdentity(claims, Options.AuthenticationType);
            return new AuthenticationTicket(claimsId, new AuthenticationProperties());// can use AuthenticationProperties to set additional propertiues needed in ticket
        }
        // override ApplyResponseChallengeAsync
     }
