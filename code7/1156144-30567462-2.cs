        [Export(typeof(ILogger))]
    class VoidLogger : ILogger
    {
        public void Log()
        {
            Console.Write("Void Logging");
        }
    }
    [Export(typeof(IDoNothing))]
    class DoNothingStub : IDoNothing
    {
        public void doNothing()
        {
        }
    }
    interface ILogger
    {
        void Log();
    }
    interface IDoNothing
    {
        void doNothing();
    }
