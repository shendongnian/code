    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Nancy.Owin;
    using Nowin;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var myNancyAppFunc = NancyMiddleware.UseNancy()(NancyOptions options =>
            {
                // Modify Nancy options if desired;
                return Task.FromResult(0);
            });
    
            using (var builder = ServerBuilder.New()
                .SetOwinApp(myNancyAppFunc)
                .SetEndPoint(new IPEndPoint(IPAddress.Any, 8080))
                .SetCertificate(new X509Certificate2("certificate.pfx", "password"))
                .Build()
            )
            {
                builder.Start();
                Console.WriteLine("Running on 8080");
                Console.ReadLine();
            }
        }
    }
