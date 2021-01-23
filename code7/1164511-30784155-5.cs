    public static class AObjectExtensions
    {
        public static void DoSomething(this AObject a, string value)
        {
            ((dynamic)a).PropertyC = value;
        }
    }
