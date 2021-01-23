    class Program
    {
        static void Main(string[] args)
        {
            // Use a collection instead of an array, as length is as of yet unknown:
            List<int> numbers;
            int high, low, sum;
            double avg;
            numbers = FillArray();
            Statistics(numbers, out high, out low, out sum, out avg);
            foreach (var number in numbers)
            {
                Console.Write("{0, 4}", number);
            }
            Console.WriteLine();
            Console.WriteLine("The array has {0} values", numbers.Count);
            Console.WriteLine("The highest value is {0}", high);
            Console.WriteLine("The lowest value is {0}", low);
            Console.WriteLine("The sum of the array is {0}", sum);
            Console.WriteLine("The average is {0}", avg);
            Console.ReadKey();
        }
        private static List<int> FillArray(int maximum = 10)
        {
            const int QUIT = 999;
            int count = 0;
            int addNum = 0;
            var list = new List<int>();
            while (count <= maximum)
            {
                Console.Write("Enter a number or 999 to exit: ");
                if (!int.TryParse(Console.ReadLine(), out addNum))
                {
                    Console.WriteLine("Error");
                    continue;
                }
                if (addNum == QUIT)
                {
                    break;
                }
                list.Add(addNum);
                count++;
            }
            return list;
        }
        private static void Statistics(List<int> numbers, out int high, out int low, out int sum, out double avg)
        {
            high = numbers.Max();
            low = numbers.Min();
            sum = numbers.Sum();
            avg = numbers.Average();
        }
    }
