    class MyClass
    {
        bool[,] matrix = new bool[,]
        {            
            {false, true, false},  // x1 y123
            {true, false, true},   // x2 y123
            {true, false, false},  // x3 y123
        };
        string[] xValues = { "A", "B", "C" };
        string[] yValues = { "A", "B", "C" };
        public bool IsValid(string value1, string value2)
        {
            return matrix[Array.IndexOf(xValues, value1), Array.IndexOf(yValues, value2)];
        }
    }
    class Program
    {
        static void Main()
        {
            MyClass c = new MyClass();
            Console.WriteLine(c.IsValid("A", "A"));
            Console.WriteLine(c.IsValid("B", "C"));
            Console.WriteLine(c.IsValid("A", "C"));
            Console.ReadKey();
        }
    }
