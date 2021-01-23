    static void Main(string[] args)
        {
            System.Console.WriteLine("\nPress any key to start the wcf client.");
            System.Console.ReadKey();
            System.Console.WriteLine("*************Calling Hello Service*************");
            try
            {
                var binding = CreateDefaultHttpBinding();
                var address = new EndpointAddress("http://cluster.region.cloudapp.azure.com/"); //new EndpointAddress("http://localhost");
                var results = WcfWebClient<IHello>.InvokeRestMethod(x => x.Hello(),binding, address ); 
                
                System.Console.WriteLine($"*************Results from Hello Service: '{results}'*************");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"*************Exception calling Hello Service: '{e}'*************");
            }
        }
