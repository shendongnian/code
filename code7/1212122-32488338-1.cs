    public class LowCalorieAuthenticationHandler : AuthenticationHandler<LowCalorieAuthenticationOptions>
    {
        //Going to give you the user for the request.. You Need to do 3 things here
        //1. Get the user claim from teh request somehow, either froma header, request string, or cookie what ever you want
        //2. validate the user with whatever user store or 3rd party SSO you want
        //3. Generate a AuthenticationTicket to send to on to the request, you can use that to see if the user is valid in any Identity collection you want.  
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
          
            //Good to throw in a point of override here.. but to keep it simple-ish
            string requestToken = null;
            string authorization = Request.Headers.Get("Authorization");
            //TOTAL FAKEOUT.. I am going to add a bearer token just so the simple sample works, but your client would have to provide this
            authorization = "Bearer  1234567869";
            //STEP 1 
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                requestToken = authorization.Substring("Bearer ".Length).Trim();
                return await FakeExternalBearer(requestToken);
            }
            
            return null;
        }
        private async Task<AuthenticationTicket> FakeExternalBearer(string token)
        {
            var authenticationType = Options.AuthenticationType;
            //pretend to call extenal Resource server to get user //STEP 2
            //CallExternal(token)
            //Create the AuthTicket from the return.. I will fake it out
            var identity = new ClaimsIdentity(
                                authenticationType,
                                ClaimsIdentity.DefaultNameClaimType,
                                ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,"user1", null, authenticationType));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Jon",null, authenticationType));
            var properties = new AuthenticationProperties();
            properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(1);
            properties.IssuedUtc = DateTime.UtcNow;
            var ticket =  new AuthenticationTicket(identity, properties);
            return ticket;
        }
    }
