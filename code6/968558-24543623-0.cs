    Proxy p = new Proxy(new List<string>() { "122.129.107.3:8080" }); //real proxies...
    WebClient wc = new WebClient();
    wc.Proxy = new WebProxy("127.0.0.1", 8888); //local proxy(fiddler core)
    wc.Headers["User-Agent"] = "SO/1.0";
    var html = wc.DownloadString("http://google.com");
---
    public class Proxy
    {
        List<string> _Proxies = null;
        public Proxy(List<string> proxies)
        {
            _Proxies = proxies;
            Fiddler.FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            Fiddler.FiddlerApplication.Startup(8888, false, true);
        }
        static long _Sequence = 0;
        void FiddlerApplication_BeforeRequest(Fiddler.Session oSession)
        {
            var sequence = Interlocked.Increment(ref _Sequence);
            string proxy = _Proxies[(int)(sequence % _Proxies.Count)];
            oSession["x-OverrideGateway"] = proxy;
            Console.WriteLine(String.Format("Proxy[{0}]> {1}", proxy, oSession.host));
        }
    }
