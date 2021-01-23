    public class LoggerDecorator : IMyInterface
    {
        private readonly IMyInterface _MyInterface;
        private readonly ILog _MyLog;
        public LoggerDecorator(IMyInterface myInterface, ILog myLog)
        {
            if (myInterface == null)
                throw new ArgumentNullException("IMyInterface is null");
            _MyInterface = myInterface;
            if (myLog == null)
                throw new ArgumentNullException("ILog instance is null");
            _MyLog = myLog;
            // This is change 1.
            _MyInterface.SomeEvent += _MyInterface_SomeEvent;
        }
        // This is change 2
        private void _MyInterface_SomeEvent(object sender, EventArgs e)
        {
            var someEvent = SomeEvent;
            if (someEvent != null)
            {
                someEvent(this, e);
            }
        }
        public string GetName()
        {
            // If needed I can use log here
            _MyLog.Info("GetName method is called.");
            return _MyInterface.GetName();
        }
        // Is this the way to set properties?
        public string IpAddress
        {
            get
            {
                return _MyInterface.IpAddress;
            }
            set
            {
                // If needed I can use log here
                _MyLog.Info("IpAddress is set.");
                _MyInterface.IpAddress = value;
            }
        }
        
        public event EventHandler SomeEvent;
    }
