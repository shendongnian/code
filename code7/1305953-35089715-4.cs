    class HASPClass
    {
        private static ParameterObject _parameters;
        private static Lazy<HASPClass> _instance = new Lazy<HASPClass>(() => 
        {
            if (_parameters == null) 
            {
                throw new InvalidOperationException("Can get instance before initializing");
            }
            return new HASPClass(_parameters);
        });
        public static HASPClass Instance
        {
           get { return _instance.Value; }
        }
        private HASPClass(ParametersObject parameters)
        {
            // create and populate your object using values from parameters
        }
        public static void Initialize(ParameterObject parameters)
        {
            if (_parameters != null) 
            {
                // you might throw an exception here if this is not allowed
                // Or you might drop and recreate your object if it is allowed
            }
            _parameters = parameters;
        } 
    }
