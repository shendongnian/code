    public class ShipmentRepository
    {
        public ShipmentRepository()
        {
        }
        public void Load()
        {
            //Simulate work
            Thread.Sleep(1000);
            if (LoadingComplete != null)
                LoadingComplete(this, new EventArgs());
            Console.WriteLine("Finished loading shipments");
            DoAditionalWork();
        }
        private void DoAditionalWork()
        {
            //Do aditional work after everything is loaded
            Thread.Sleep(5000);
            Console.WriteLine("Finished aditional shipment work");
        }
        public event EventHandler LoadingComplete;
    }
