    MyProxy.Start();
    webBrowser1.Navigate(url);
----
    public class MyProxy
    {
        public static void Start()
        {
            Fiddler.FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            Fiddler.FiddlerApplication.Startup(8888, true, true);
        }
        static void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            oSession["X-OverrideGateway"] = "94.76.117.14:8080"; // <-- Your Http Proxy
            //oSession["x-OverrideGateway"] = "socks=ip:port"; //For socks proxy 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(oSession.fullUrl);
        }
        public static void Stop()
        {
            Fiddler.FiddlerApplication.Shutdown();
        }
    }
