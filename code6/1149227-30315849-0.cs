    class Program
    {
        static void Main(string[] args)
        {
            const int retrieve = 6;
            const int maxNumber = 40;
            const int maxLine = 20;
            var numbers = Enumerable.Range(1, maxNumber).ToArray();
            var rnd = new Random();
            int[] result = new int[retrieve];
            int pos;
            for (int j = 0; j < maxLine; ++j)
            {
                int number = numbers.Length;
                for (int i = 0; i < retrieve; ++i)
                {
                    pos = rnd.Next(0, number);
                    result[i] = numbers[pos];
                    number--;
                    numbers[pos] = numbers[number];
                    numbers[number] = result[i];
                }
                Console.WriteLine(string.Join(", ",result.OrderBy (x => x).Select(x => x.ToString("00")).ToArray()));
            }
            Console.ReadKey(false);
        }
    }
