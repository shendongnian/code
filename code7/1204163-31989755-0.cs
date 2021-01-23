    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("x", 1);
            dict.Add("y", 2);
            dict.Add("z", 3);
            var reversed = dict.ToArray().Reverse();
            var reversedArray = reversed.ToArray();
            Console.ReadKey();
        }
    }
