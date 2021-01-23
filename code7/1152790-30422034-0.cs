     public static void Main(string[] args)
            {
                string answer;
    
                Console.WriteLine("Would you like to divide or multiply? Type your choice.");
    
            Start:
                answer = (Console.ReadLine());
    
                if (answer == "multiply")
                {
                    MultiplyingMethod();
                }
                else if (answer == "divide")
                {
                    DividingMethod();
                }
                else
                {
    
                    Console.WriteLine("Please type multiply or divide.");
    
                    goto Start;
                }
    
            }
            public static void DividingMethod()
            {
                double num01;
                double num02;
    
                Console.Write("Enter a number to be divided");
                num01 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter a number to divide by");
                num02 = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine(num01 + " divided by " + num02 + " is equal to " + num01 / num02);
    
                Console.WriteLine("");
                Console.ReadKey();
    
            }
            public static void MultiplyingMethod()
            {
                double num01;
                double num02;
    
                Console.Write("Enter a number to be multiplied");
                num01 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter a numeber to multiply by");
                num02 = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine(num01 + " multiplied by " + num02 + " equals " + num01 * num02);
    
                Console.WriteLine("");
                Console.ReadKey();
    
            }
