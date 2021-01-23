    namespace ExtensionTest
    {
        public class MyClass
        {
            public string MyMethod(string something)
            {
                System.Console.Out.WriteLine(string.Format("Hi! This is something! {0}", something));
                return something + " something else";
            }
        }
    }
    namespace ExtensionTest
    {
        public static class MyExtension
        {
            public static string MyExtensionMethod(this MyClass myclass, string something)
            {
                System.Console.Out.WriteLine(string.Format("This is the extension {0}", something));
                string somethingelse = myclass.MyMethod(something);
                return somethingelse + " more of something";
            }
        }
    }
