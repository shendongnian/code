    kernel.Bind<UnitCollector>().ToMethod(c => new UnitCollector(
        c.Get<Config>().Setting1,
        LogFactory.CreateLog(typeof(UnitCollector))));
    class UnitCollector {
        private readonly string _param2;
        private readonly ILogger _logger;
        public UnitCollector(string param2, ILogger logger) {
            _param2 = param2;
            _logger = logger;
        }
        public bool ProcessUnit(string data, string param1) {
            // Perhaps even better to extract both parameters into a
            // Parameter Object: https://bit.ly/1AvQ6Yh
        }
    }
        
    class Service {
        private readonly ILogger _logger;
        private readonly Func<UnitCollector> _collectorFactory;
        public Service(ILogger logger, Func<UnitCollector> collectorFactory) {
            _logger = logger;
            _collectorFactory = collectorFactory;
        }
        public void DoStuff() {
            UnitCollector currentCollector = null;
            bool lastResult = false;
            while (true) {
                Message message = ReceiveMessage();
                if (!lastResult) {
                    currentCollector = this.collectorFactory.Invoke();
                }
                lastResult = currentCollector.ProcessUnit(message.Param1, message.Param2);
            }
        }
    }    
