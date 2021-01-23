    public class WebConnectionStats
    {
        static int _Read = 0;
        static int _Written = 0;
        public static void Init(bool registerAsSystemProxy = false)
        {
            Fiddler.FiddlerApplication.OnReadRequestBuffer += (s, e) => Interlocked.Add(ref _Written, e.iCountOfBytes);
            Fiddler.FiddlerApplication.OnReadResponseBuffer += (s, e) => Interlocked.Add(ref _Read, e.iCountOfBytes);
            Fiddler.FiddlerApplication.Startup(8088, registerAsSystemProxy, true);
        }
        public static int Read
        {
            get { return _Read; }
        }
        public static int Written
        {
            get { return _Written; }
        }
    }
---
    WebConnectionStats.Init(); //call this only once
    var client = HttpWebRequest.Create("http://stackoverflow.com") as HttpWebRequest;
    client.Proxy = new WebProxy("127.0.0.1", 8088);
    var resp = client.GetResponse();
    var html = new StreamReader(resp.GetResponseStream()).ReadToEnd();
    Console.WriteLine("Read: {0}   Write: {1}", WebConnectionStats.Read, 
                                                WebConnectionStats.Written);
