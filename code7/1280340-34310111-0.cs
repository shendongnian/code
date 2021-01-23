        static string A<T>(IEnumerable<T> collection)
        {
            return "method for ienumerable";
        }
        static string A<T>(T item)
        {
            return "method for single element";
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 5, 3, 7 };
            Console.WriteLine(A(numbers));
        }
