    public class Locator
    {
        public static class LocatorInner<T> where T : BaseClass
        {
            public static string Name { get; set; }
        }
        public static string GetName<T>() where T : BaseClass
        {
            return LocatorInner<T>.Name;
        }
        public static void SetName<T>(string name) where T : BaseClass
        {
            LocatorInner<T>.Name = name;
        }
    }
    public class BaseClass
    {
    }
    public class DerivedClass: BaseClass
    {
        static DerivedClass()
        {
            Locator.LocatorInner<DerivedClass>.Name = "me";
        }
    }
    
    public class TestClass<T> where T : BaseClass
    {
        public void Method()
        {
            var name = Locator.GetName<T>();
        }
    }
