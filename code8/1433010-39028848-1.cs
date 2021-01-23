    class Program
    {
        static int Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.CaseSensitive = false;
                settings.HelpWriter = Console.Error;
                settings.IgnoreUnknownArguments = false;
            });
    
            var result = parser.ParseArguments<Options>(args);
            var exitCode = result
    .MapResult(
      options =>
      {
    
          if (options.StringSequence.Count() > 0)
          {
              Console.WriteLine("unbound params: " +
              String.Join(",", options.StringSequence)
              );
              return 1;
          }
          Console.WriteLine("Hi " + options.UserName + ", your password is");
          Console.WriteLine(options.Password);
          return 0;
      },
      errors =>
      {
          Console.WriteLine(
              String.Join(",",
              errors.Select(x => x.ToString())
              )
              );
          return 1;
      });
            return exitCode;
        }
    }
