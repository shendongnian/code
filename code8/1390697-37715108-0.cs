    class Program
    {
        static void Main(string[] args)
        {
            InheredClass test = new InheredClass(); // Do this
            BaseClass test2 = new InheredClass(); // don't do this
            Console.WriteLine(test.MyProperty.GetType());
            Console.WriteLine(test2.MyProperty.GetType());
            Console.Read();
        }
        class BaseClass
        {
            public int MyProperty { get; set; }
        }
        class InheredClass : BaseClass
        {
            new public decimal MyProperty { get; set; }
        }
    }
