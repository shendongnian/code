      private bool Authenticate(string user, string password)
      {
            using ( var context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName) ) {
               return context.ValidateCredentials(user, password);
            }
      }
