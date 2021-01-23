    public static class SomeStaticClass
    {
        public static int SomeStaticMethod(string s)
        {
            return "Static method called: " + s;
        }
    }
    public class SomeInstanceClass
    {
        public string SomeInstanceMethod(string s)
        {
            return SomeStaticClass.SomeStaticMethod(s);
        }
    }
