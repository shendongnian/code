    public class UserLogin
    {
         public string Name { get; set; }
         public string Password { get; set; }
    }
    public class UserLoginSpec
    {
           // This could be a simplified way of storing broken rules,
           // where keys are the affected resource or property by the
           // rule, and the value, a human-readable description of what
           // happened with the broken rule...
           public Dictionary<string, string> BrokenRules { get; } = new Dictionary<string, string>();
    
           public bool IsSatisfiedBy(UserLogin login)
           {
                Contract.Requires(login != null);
    
                if(string.IsNullOrEmpty(login.Name))
                     BrokenRules.Add("Name", "Name cannot be empty");
    
                if(string.IsNullOrEmpty(login.Password))
                     BrokenRules.Add("Password", "Password cannot be empty");
    
                // The spec is passed if no broken rule has been added
                return BrokenRules.Count == 0;
           }
    }
    public class UserLoginResult
    {
          public UserLoginResult(UserLoginSpec spec)
          {
                Contract.Requires(spec != null);
                Successful = spec.BrokenRules.Count == 0;
                Errors = spec.BrokenRules;
          }
          public bool Successful { get; private set; }
          public Dictionary<string, string> Errors { get; private set; }
    }
