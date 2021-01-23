    public class SomeClass
    {
        public SomeClass(string s) : this(dosomething(s))
        {
            
        }
        public SomeClass(int[] something)
        {
        }
        private static int[] dosomething(string)
        {
            return new int[] { };
        }
    }
