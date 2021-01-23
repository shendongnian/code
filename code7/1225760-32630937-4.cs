    public static class Extensionparameters
     {
        private static parameters _initialParameters;
        public static void RegisterObject(this parameters parameters)
        {
            _initialParameters = parameters;
        }
        public static String CheckChanges(this parameters value)
        {
            if (value.bar != _initialParameters.bar || value.foo != _initialParameters.foo ||
                value.widget != _initialParameters.widget)
            {
                return "1";
            }
            return "0";
        }
    }
