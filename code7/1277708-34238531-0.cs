    using Nito.AsyncEx;    
    static void Main(string[] args)
    {
      AsyncContext.Run(() => MainAsync(args));
    }        
            
    static async void MainAsync(string[] args)
    {
      Console.Write("Enter URL: ");
      string url = Console.ReadLine();
        
      await GetPageHTML(url);
      Console.ReadKey();
    }
