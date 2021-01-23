    class Program
    {
        static CountdownEvent countdownEvent;
        static void Main(string[] args)
        {
            var numThreads = 3; //The number of task you will be running
            countdownEvent = new CountdownEvent(numThreads);
    
            //Start shipment loading task and hook event
            //Start container loading task and hook event
            //Start package loading task and hook event
    
            // Wait till everything is loaded.
            countdownEvent.Wait();
            LoadView();
            //Continue with main thread
        }
        static void ShipmentRepository_LoadingComplete(object sender, EventArgs e)
        {
            countdownEvent.Signal();
        }
        static void ContainerRepository_LoadingComplete(object sender, EventArgs e)
        {
            countdownEvent.Signal();
        }
    
        static void PackageRepository_LoadingComplete(object sender, EventArgs e)
        {
            countdownEvent.Signal();
        }    
    }
