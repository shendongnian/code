      public class MyAuthRequirement : AuthorizationHandler<MyAuthRequirement>, IAuthorizationRequirement
      {
         public override void Handle(AuthorizationContext context, MyAuthRequirement requirement)
         {
            // grab the identity for the MyAuth authentication
            var myAuthIdentities = context.User.Identities
               .Where(x => x.AuthenticationType == MyAuthOptions.Scheme).FirstOrDefault();
            if (myAuthIdentities == null)
            {
               context.Fail();
               return;
            }
            // grab the authentication header and uri types for our identity
            var authHeaderClaim = myAuthIdentities.Claims.Where(x => x.Type == ClaimTypes.Authentication).FirstOrDefault();
            var uriClaim = context.User.Claims.Where(x => x.Type == ClaimTypes.Uri).FirstOrDefault();
            if (uriClaim == null || authHeaderClaim == null)
            {
               context.Fail();
               return;
            }
            // enforce our requirement (evaluate values from the identity/claims)
            if ( /* passes our enforcement test */ )
            {
               context.Succeed(requirement);
            }
            else
            {
               context.Fail();
            }
         }
      }
