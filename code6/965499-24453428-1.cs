    internal class Program
    {
        private static void Main()
        {
            var client = new JsonServiceClient(Settings.Default.ServiceAddress);
            var shipInfo = client.Post<ShipInfo>(new AddShipCommand { ShipName = "Star" });
            Console.WriteLine("The ship has added: {0}", shipInfo);
    
            var shipLocation = client.Get<ShipLocation>(new ShipLocationQuery { ShipId = shipInfo.Id });
            Console.WriteLine("The ship {0}", shipLocation);
    
            Console.ReadKey();
        }
    }
