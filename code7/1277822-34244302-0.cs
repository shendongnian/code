    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = new List<int>() { 0, 1, 2, 3, 4 };
            List<int> numbers2 = new List<int>() { 5, 6, 7, 8, 9 };
            DisplayBoxedInts(numbers1);
            DisplayBoxedInts(numbers2);
            Console.ReadLine();
        }
        public static void DisplayBoxedInts(IEnumerable<int> numbers)
        {
            var boxLine1 = "ooooooo ";
            var boxLine2 = "o     o ";
            var boxLine3 = "o  {0}  o ";
            var boxLine4 = "o     o ";
            var boxLine5 = "ooooooo ";
            var count = numbers.Count();
            var multiBoxLine1 = string.Empty;
            var multiBoxLine2 = string.Empty;
            var multiBoxLine3 = string.Empty;
            var multiBoxLine4 = string.Empty;
            var multiBoxLine5 = string.Empty;
            foreach (var num in numbers)
            {
                multiBoxLine1 += boxLine1;
                multiBoxLine2 += boxLine2;
                multiBoxLine3 += string.Format(boxLine3, num);
                multiBoxLine4 += boxLine4;
                multiBoxLine5 += boxLine5;
            }
            Console.WriteLine(multiBoxLine1);
            Console.WriteLine(multiBoxLine2);
            Console.WriteLine(multiBoxLine3);
            Console.WriteLine(multiBoxLine4);
            Console.WriteLine(multiBoxLine5);
        }
    }
