    class Program
    {
        static void Main(string[] args)
        {
            var w = new TypeA {i = 8};
            var x = new TypeA {i = 16};
            var y = new TypeB {i = 32};
            var z = new TypeC(); // don't pass this to Test!
            var l = new List<dynamic> {w, x, y};
            Test(l);
        }
        private static void Test(IEnumerable<dynamic> inputs)
        {
            foreach (var input in inputs)
            {
                logic(input.i);
            }
        }
        private static void logic(int i)
        {
            // magic happens here
        }
    }
    class TypeA
    {
        public int i;
    }
    class TypeB
    {
        public int i;
    }
    class TypeC {} // no members 
