    static void Main(string[] args)
           {
                  string user = string.Empty;
                  string password = string.Empty;
                  int verbose = 0;
                  var p = new OptionSet () {
           	       { "u|user",      v => user = v },
           	       { "p|password",  v => password = v },
                  };
                  List<string> extra = p.Parse (args);
                  Console.WriteLine($"user:{user}");
           }
