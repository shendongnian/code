     static void Main()
        {
            long sum = 0;
            List<int> passedValues = new List<int>();
            for (int i = 1; i < 10000; i++)
            {
                var number1 = SumOfNumber(i);
                var number2 = SumOfNumber(SumOfNumber(i));
     
                if (number2 == i && i < number1)
                {
                    sum = sum + i + number1;
  
                }
            }
            Console.WriteLine(sum );
            Console.ReadKey();
        }
        private static int SumOfNumber(int input)
        {
            int sum = 0;
            for (int i = 1; i <= input / 2; i++)
            {
                if (input % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
