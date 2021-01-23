    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registering dependencies ...");
            var container = new UnityContainer();
            container.RegisterType<ProgramStarter, ProgramStarter>();
            // Do other registrations.
            var program = container.Resolve<ProgramStarter>();
            // Since ProgramStarter was resolved using Unity it will also resolve the container.
            program.Run();
        }
    }
    public class ProgramStarter
    {
        public ProgramStarter(IUnityContainer container)
        {
            // Do something with container.
        }
    
        public Run()
        {
            // Do stuff.
        }
    }
