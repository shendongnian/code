    using System.Threading;
    
    public static void Main(string[] args)
    {
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
    
        new Thread(new ThreadStart(StartBrowser)).Start();
    
        host.Run();            
    }
    
    public static void StartBrowser()
    {
        Thread.Sleep(1000);
    
        try
        {
            System.Diagnostics.Process.Start("cmd", "/C start http://google.com"); // Windows only...
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
