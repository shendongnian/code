            set
            {
                var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
                var Identity = new ClaimsIdentity(User.Identity);
                Identity.RemoveClaim(Identity.FindFirst("AccountNo"));
                Identity.AddClaim(new Claim("AccountNo", value));
                AuthenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant
    (new ClaimsPrincipal(Identity), new AuthenticationProperties { IsPersistent = true });
    
    
            }
