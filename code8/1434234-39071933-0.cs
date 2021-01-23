    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering dependencies ...");
            var container = new UnityContainer();
            container.RegisterType<ProgramStarter, ProgramStarter>(); // Register a class that continues your program.
            // Do your registrations.
            RegisterTypes(container);
          
            // Let Unity resolve ProgramStarter and create a build plan.
            var program = container.Resolve<ProgramStarter>();
            Console.WriteLine("All done. Starting program...");
            program.Run();
        }
    }
