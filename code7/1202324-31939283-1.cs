                int first = 0;
                int second = 1;
                int third = 1;
                List<int> fibnoList= new List<int>();                  
                for (int i = 0; i < 50; i++)
                {
                    fibnoList.Add(second);    
                    third = second;
                    second = first + second;
                    first = third;                                    
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
