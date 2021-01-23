        public interface ILogger
        {
            void ErrorLogging(string input);
        }
        
        public class MyClassthatDoesStuff
        {
            private readonly ILogger _logger;
            public MyClassthatDoesStuff(ILogger logger)
            {
                _logger = logger;
            }
        }
