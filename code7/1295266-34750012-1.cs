      public SignInResponseMessage Generate<T>(SignInRequestMessage request, 
                                              Func<T, ClaimsIdentity> createSubject, 
                                              T principal, 
                                              Uri requestUri)
      {
          SignInResponseMessage response = null;
          ClaimsIdentity identity = null;
          if (principal != null)
          {
              identity = createSubject(principal);
              response = Generate(request, requestUri, identity);
          }
          else
          {
              throw new ArgumentNullException("principal");
          }
          return response;
      }
