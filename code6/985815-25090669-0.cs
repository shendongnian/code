    namespace MyNamespace
    {
        public interface ISomeInterface { }
        public static class SomeInterfaceExtensions
        {
            public static string DoSomething(this ISomeInterface someObject)
            {
                //Do something
                return "I did something";
            }
        }
    }
