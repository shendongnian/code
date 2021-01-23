    using MyNamespace;
    namespace ControllerAccessibleNamespace
    {
        public static class SomeInterfaceExtensions
        {
            public static string DoSomethingWrapper(this ISomeInterface someObject)
            {
                return someObject.DoSomething();
            }
        }
    }
