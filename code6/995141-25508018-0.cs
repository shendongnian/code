    public class ChunkedResponse : Response
    {
        public ChunkedResponse()
        {
            Headers["Transfer-Encoding"] = "chunked";
            Headers["Content-Encoding"] = "gzip";
            ContentType = "text/html; charset=utf-8";
            Contents = stream =>
            {
                var gzip = new ICSharpCode.SharpZipLib.GZip.GZipOutputStream(stream);
                using (var streamWriter = new StreamWriter(gzip))
                {
                    while (true)
                    {
                        streamWriter.WriteLine("Hello");
                        gzip.Flush();
                        streamWriter.Flush();
                        Thread.Sleep(1000);
                    }
                }
            };
        }
    }
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = args => new ChunkedResponse();
        }
    }
    public class Program
    {
        public static void Main()
        {
            using (var host = new NancyHost(new HostConfiguration{AllowChunkedEncoding = true},new Uri("http://localhost:1234")))
            {
                
                host.Start();
                Console.ReadLine();
            }
        }
    }
