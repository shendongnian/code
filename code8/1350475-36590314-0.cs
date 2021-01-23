    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ProgramStarter, ProgramStarter>();
            // Pass the same container to the config.
            FeePaymentTracker.UnityConfig.RegisterComponents(container);
            var program = container.Resolve<ProgramStarter>();
            program.Run();
        }
    }
    public class ProgramStarter
    {
        IRecurringTransactionPlanDataService _dataService;
        public ProgramStarter(IRecurringTransactionPlanDataService dataService)
        {
            _dataService = dataService;
        }
        public void Run()
        {
            // Do stuff.
        }
    }
