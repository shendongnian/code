                int first = 0;
                int second = 1;
                int third = 1;
                List<int> fibnoList= new List<int>();
                fibnoList.Add(1);         
                for (int i = 0; i < 50; i++)
                {
                    third = second;
                    second = first + second;
                    first = third;
                   fibnoList.Add(second);                      
                }
                Console.WriteLine("Enter a number to find if it's in Fibonacci      range:");
                int number = int.Parse(Console.ReadLine());
                if (fibnoList.Contains(number))
                {
                    Console.WriteLine("Your number is within the Fibonacci range.");
                }
                else
                {
                    Console.WriteLine("Your number is NOT within the Fibonacci range");
                }
