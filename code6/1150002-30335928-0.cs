    public interface IProcedure
    {
        void Run();
    }
    public class RealProcedure : IProcedure
    {
        public void Run()
        {
            // Do interesting stuff
        }
    }
    public class LoggingProcedure : IProcedure
    {
        private readonly IProcedure _procedure;
        public LoggingProcedure(IProcedure procedure)
        {
            if (procedure == null)
                throw new ArgumentNullException("procedure");
            _procedure = procedure;
        }
        public void Run()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            _procedure.Run();
            stopWatch.Stop();
            // Log elapsed time with w/e you are using for logging.
        }
    }
