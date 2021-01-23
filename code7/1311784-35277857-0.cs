    class Program
        {
            private static string _STOP = "STOP";
            private static int _MAX_SIZE = 10;
                
            static void Main(string[] args)
            {
                List<int>numbers = FillList();
        
                foreach(int number in numbers)
                    Console.Write("{0, 4}", number);
        
                Console.WriteLine();
                Console.WriteLine("The list has {0} values", numbers.Count);
                Console.WriteLine("The highest value is {0}", numbers.Max());
                Console.WriteLine("The lowest value is {0}", numbers.Min());
                Console.WriteLine("The sum of the array is {0}", numbers.Sum());
                Console.WriteLine("The average is {0}", numbers.Average());
                Console.ReadKey();
        
            }
        
            private static List<int> FillList()
            {
                List<int> numbers = new List<int>();
                int value;
                int count = 0;
                do
                {
                    Console.Write("Enter a number or {0} to exit: ", _STOP);
                    string line = Console.ReadLine();
                    if (line == _STOP)
                        break;
        
                    if (int.TryParse(line, out value))
                    {
                        numbers.Add(value);
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Error reading number.");
                    }
                } while (count < _MAX_SIZE);
        
                return numbers;
            }
        }
