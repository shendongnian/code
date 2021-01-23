    class Program
    {
        public static void Main(string[] args)
        {
            // Register at B
            BLibClass.BEvent += MyMethod;
            // Something triggers A
            BLibClass.ATrigger();
            Console.ReadKey();
        }
        public static void MyMethod()
        {
            System.Console.WriteLine("Something happeneds!");
        }
    }
