    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static double pair_sum(double[] numbers)
            {
                if (numbers.Length==1)
                {
                    return numbers[0];
                }
                var new_numbers = new double[(numbers.Length + 1) / 2];
                for (var i = 0; i < numbers.Length - 1; i += 2) {
                    new_numbers[i / 2] = numbers[i] + numbers[i + 1];
                }
                if (numbers.Length%2 != 0)
                {
                    new_numbers[new_numbers.Length - 1] = numbers[numbers.Length-1];
                }
                return pair_sum(new_numbers);
            }
            static void Main(string[] args)
            {
                var numbers = new double[1000000];
                for (var i = 0; i < numbers.Length; i++) numbers[i] = 0.1;
                Console.WriteLine(numbers.Sum());
                Console.WriteLine(pair_sum(numbers));
            }
        }
    }
