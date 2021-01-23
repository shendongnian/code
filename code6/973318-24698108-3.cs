    class Program
    {
        static void Main(string[] args)
        {
            var myWpfObject = new MyWpfObject();
        }        
    }
    public class MyWpfObject
    {
        CountdownEvent countdownEvent;
        public MyWpfObject()
        {
            ShipmentRepository ShipmentRepository = new ShipmentRepository();
            ContainerRepository ContainerRepository = new ContainerRepository();
            PackageRepository PackageRepository = new PackageRepository();
            ShipmentRepository.LoadingComplete += Repository_LoadingComplete;
            ContainerRepository.LoadingComplete += Repository_LoadingComplete;
            PackageRepository.LoadingComplete += Repository_LoadingComplete;
            Task[] loadingTasks = new Task[] {
                new Task(ShipmentRepository.Load),
                new Task(ContainerRepository.Load),
                new Task(PackageRepository.Load)
            };
            countdownEvent = new CountdownEvent(loadingTasks.Length);
            foreach (var task in loadingTasks)
                task.Start();
            // Wait till everything is loaded.
            countdownEvent.Wait();
            Console.WriteLine("Everything Loaded");
            
            //Wait till aditional tasks are completed.
            Task.WaitAll(loadingTasks);
            Console.WriteLine("Everything Completed");
            Console.ReadKey();
        }
        public void Repository_LoadingComplete(object sender, EventArgs e)
        {
            countdownEvent.Signal();
        }
    }
