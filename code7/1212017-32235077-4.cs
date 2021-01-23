    class Program
    {
        static void Main(string[] args)
        {
            var t2 = new Test2("blah");
        }
    }
    class Test1
    {
        public Test1()
        {
            Debug.WriteLine("I'm in Test1.ctor()");
        }
    }
    class Test2: Test1
    {
        public Test2()
        {
            Debug.WriteLine("I'm in Test2.ctor()");
            Initialize();
        }
        public Test2(string blah) : this()
        {
            Debug.WriteLine("I'm in Test2.ctor(string blah)");
        }
        private void Initialize()
        {
            Debug.WriteLine("I'm in Test2.Initialize()");
        }
    }
