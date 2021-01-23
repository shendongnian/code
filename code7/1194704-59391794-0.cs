      class Program
    {
        static void Main(string[] args)
        {
            ClassB b = new ClassB()
            {
                PropclassA = new ClassA()
                {
                    TestProp = 10,
                }
            };
            ClassB b1 = new ClassB();
            b1.PropclassA.TestProp = 100;
        }
    }
    class ClassA
    {
        public int TestProp { get; set; }
    }
    class ClassB
    {
        public ClassB()
        {
            PropclassA = new ClassA();
        }
        public ClassA PropclassA { get; set; }
    }
