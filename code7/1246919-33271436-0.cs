    namespace PingApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pinger = new WebSitePing();
                pinger.Ping();
            }
        }
    }
