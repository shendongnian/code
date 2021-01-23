    class Program
    {
        static IDisposable app1;
        static IDisposable app2;
        static void Main(string[] args)
        {
              launchServices("http://localhost:4234", "http://localhost:4265");
              Console.ReadLine();
              app1.Dispose();
              app2.Dispose();
              
        }
        public static void launchServices(string url1, string url2)
        {
              app1 = WebApp.Start<StartupApp1>(url1);
              app2 = WebApp.Start<StartupApp2>(url2);
        }
    }
