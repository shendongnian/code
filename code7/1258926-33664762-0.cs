    // add such a module class to your assembly, Nancy should find it automagically
    public class ResourceModule : NancyModule
    {
        public ResourceModule() : base("/products")
        {
            // would capture routes to /products/list sent as a GET request
            Get["/list"] = parameters => {
                return "The list of products";
            };
        }
    }
    
    // then start the host
    using (var host = new NancyHost(new Uri("http://localhost:1234")))
    {
       host.Start();
       // do whatever other work needed here because once the host is disposed of the server is gone 
       Console.ReadLine();
    }
