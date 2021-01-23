        public class DuckProjectRegistry : Registry
        {
            public DuckProjectRegistry()
            {
                For<IDataAccess >().Use<ConcreteClassDataAccess>();
                For<IConverter>().Use<ConcreteConverterXYZ>();
                For<IConfigAccess>().Use<ConcreteConfigAccess>().Singleton();
                // etc.
            }
        }
     
    public class Duck
    {
        private readonly IDataAccess _dataAccess;
        private readonly IConverter _converter;
        private readonly IConfigAccess _configAccess;
        // etc.
        public Duck(
            IDataAccess dataAccess,
            IConverter converter,
            IConfigAccess configAccess
            // ,etc.)
        {
            _dataAccess = dataAccess;
            _converter = converter;
            _configAccess = configAccess;
            // etc.
        }
