    internal class MyConfiguration
    {
        private static String MyConfigurationValue; // set in constructor
        MyConfiguration(){ MyConfigurationValue = DoSomethingToLoadValue(); }
        public static String GetMyConfigurationValue(){ return MyConfigurationValue; }
    }
