    public class TestCommand : CommandBase
    {
        private Logger logger;
    
        public TestCommand(Logger logger)
        {
            this.logger = logger;
        }
    
        public override bool CanExecute(object parameter)
        {
            return true;
        }
    
        public override void ExecuteCommand(object parameter)
        {
            logger.log(...);
            ...
        }
    }
