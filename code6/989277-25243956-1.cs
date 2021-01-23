    static void Main(string[] args)
    {
      AsyncContext.Run(() => async
      {
        using (var thread = new AsyncContextThread(true))
        {
          await thread.Factory.Run(() => MainAsync(args));
        }
      }
    }
