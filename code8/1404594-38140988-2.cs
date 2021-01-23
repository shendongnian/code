    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
     await Task.Run(
      () => {
          ...logging logic...
          var loginResult = authRepository.Login(context.UserName, context.Password);
          if (!loginResult.Success) return;
          ...logging logic...
    
          var claims = new List < Claim > ();
          claims.add(new Claim(ClaimTypes.Role, loginResult.Role)); < --here
          var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ExternalBearer);
          context.Validated(id);
      });
    }
