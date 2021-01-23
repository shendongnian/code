    public class MySocket : ISender
    {
        [Dependency]
        public Lazy<IVehicleManager> VehicleManager { get; set; }
        public void Connect()
        {
            Console.WriteLine("MySocket: Connect");
            VehicleManager.Value.AddActiveConnection();
        }
    }
