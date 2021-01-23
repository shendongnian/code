    public class A
    {
        public static string Aa = "test";
        public void test(object calledClass)
        {
            if(calledClass is B) Aa = calledClass.Bb;
        }
    }
