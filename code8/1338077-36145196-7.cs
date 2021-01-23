    using System.Reflection;
    namespace ClassLibrary1
    {
        public class Class1
        {
            public Class1()
            {
                MyDelegate myDelegate = MyDelegateInstance;
                var methodName = myDelegate.GetMethodInfo().Name;
                var baseType = typeof(Class1).GetTypeInfo().BaseType;
            }
            private delegate string MyDelegate();
            private static string MyDelegateInstance() { return string.Empty; }
        }
    }
