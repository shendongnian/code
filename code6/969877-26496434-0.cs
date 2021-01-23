    var identity = User.Identity as ClaimsIdentity;
    var newIdentity = new ClaimsIdentity(identity.AuthenticationType, identity.NameClaimType, identity.RoleClaimType);
    newIdentity.AddClaims(identity.Claims.Where(c => false == (c.Type == claim.Type && c.Value == claim.Value)));
    // the claim has been removed, you can add it with a new value now if desired
    AuthenticationManager.SignOut(identity.AuthenticationType);
    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, newIdentity);
