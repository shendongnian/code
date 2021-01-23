    static void Main(string[] args)
    {
      using (var thread = new AsyncContextThread(true))
      {
        thread.Factory.Run(() => MainAsync(args)).Wait();
      }
    }
