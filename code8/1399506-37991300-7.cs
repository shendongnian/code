    public static class StaticClassExample
    {
        public static void ClassFunction()
        {
            Console.WriteList("This is a class function")
        }
    }
    public static class InitialisedStaticClassExample
    {
        static InitialisedStaticClassExample()
        {
            Console.WriteList("This class has been initialised")
        }
        public static void ClassFunction()
        {
            Console.WriteList("This is a class function")
        }
    }
    public class PrivateConstuctorClassExample
    {
        static PrivateConstuctorClassExample()
        {
            Console.WriteList("This class has been initialised")
        }
        private PrivateConstuctorClassExample()
        {
            Console.WriteList("This class has been Instantiated")
        }
        public static void ClassFunction()
        {
            Console.WriteList("This is a class function");
            var instance = new PrivateConstuctorClassExample();
            instance.InstanceFunction();
        }
        public void InstanceFunction()
        {
            Console.WriteList("This is a instance function")
        }
    }
