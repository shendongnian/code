     var result = CommandLine.Parser.Default.ParseArguments<Options>(args);
                
     result.MapResult(
            options =>
            {
                // Do something with optios
                return 0;
            },
            errors =>
            {
                var invalidTokens = errors.Where(x => x is TokenError).ToList();
                if(invalidTokens != null)
                {
                    invalidTokens.ForEach(token => Console.WriteLine(((TokenError)token).Token));
                }
    
                return 1;
            });
