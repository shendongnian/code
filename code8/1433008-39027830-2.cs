    // Define a class to receive parsed values
    class Options {
      [Option('u', "user", Required=true, HelpText="username")]
      public string UserName { get; set; }     
      [Option('p', "password", Required=true, HelpText="password")]
      public string Password { get; set; }
    
      [ParserState]
      public IParserState LastParserState { get; set; }
    
      [HelpOption]
      public string GetUsage() {
        return HelpText.AutoBuild(this,
          (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
      }
    }
    
    // Consume them
    static void Main(string[] args) {
      var options = new Options();
      if (CommandLine.Parser.Default.ParseArguments(args, options)) 
      {
             // Values are available here
            Console.WriteLine($"UserName:{options.UserName}");
      }
    }
