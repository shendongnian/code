    class Program
    {
        static bool test(dynamic d, dynamic c)
        {
            return d.Contains(c);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(test(new List<string>(), "not found"));
        }
    }
