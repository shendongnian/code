    static void Main(string[] args)
    {
      MainAsync().Wait();
    }
    static async Task MainAsync()
    {
      try
      {
        Program program = new Program();
        var content = await program.Get(@"http://www.google.com");
        Console.WriteLine("Program finished");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
