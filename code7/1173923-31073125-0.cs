    namespace CustomNamespace
    {
        // public static SomeFreeMethod(some params) { } <- This can't be in C#
        // For your case you can use code samples below
        public static class SomeStaticClass {
            public static void SomeMethod() { }
            public static void SomeMethod(object p1, object p2);
            public static void SomeMethod(object p1, object p2, object p3);
            public static T SomeMethod<T>(T o1, T o2, T o3) { return default(T); }
        }
        public class SomeInstanceClass {
            public SomeInstanceClass() {
              // call methods from static class in instance of object
              SomeStaticClass.SomeMethod();
              SomeStaticClass.SomeMethod(3, 6);
              SomeStaticClass.SomeMethod('c', "dasda", 3);
              float someResult = SomeStaticClass.SomeMethod<float>(3.45f, 312.233f, 3.14f);
            }
        }
    }
