    public UserLoginResult Authenticate(UserLogin login)
    {
         Contract.Requires(login != null);
         Contract.Ensures(Contract.Result<UserLoginResult>() != null);
         UserLoginSpec loginSpec = new UserLoginSpec();
         if(loginSpec.IsSatisfiedBy(login))
         {
              // Actual code to validate user's credentials here
         }
         return new UserLoginResult(loginSpec);
    }
