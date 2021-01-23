     class Options
     {
         [Option('u', "user", Required = true, HelpText = "username")]
         public string UserName { get; set; }
    
         [Option('p', "password", Required = true, HelpText = "password")]
         public string Password { get; set; }
    
         [Value(0)]
         public IEnumerable<string> StringSequence { get; set; }
     }
