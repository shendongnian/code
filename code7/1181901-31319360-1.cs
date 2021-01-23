    class MyClass
    {
        bool[,] matrix = new bool[,]
        {
            {false, true, true},
            {true, false, false},
            {false, true, false},
        };
        string[] xValues = { "A", "B", "C" };
        string[] yValues = { "A", "B", "C" };
        public bool IsValid(string value1, string value2)
        {
            return matrix[Array.IndexOf(yValues, value2), Array.IndexOf(xValues, value1)];
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
