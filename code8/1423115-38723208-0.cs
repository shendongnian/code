    using System;
    
    public static void Run(string input, out object document, TraceWriter log)
    {
        log.Info($"C# manually triggered function called with input: {input}");
        document = new {
            text = $"I'm running in a C# function! {input}"
        };
    }
  
