    bool again = false;
                   do {
                    Console.WriteLine("C# Basic Calcuator");
                    Console.WriteLine("Please enter two numbers to be added: ");
                    Console.WriteLine("Number 1: ");
    
                    int result;
                    int a = Convert.ToInt32(Console.ReadLine());
    
    
                    Console.WriteLine("Number 2: ");
                    int b = Convert.ToInt32(Console.ReadLine());
    
                    Console.WriteLine("Result: ");
                    result = a + b;
    
                    //print result
                    Console.WriteLine(result);
    
                    //potential exit condition
                    Console.WriteLine("Would you like to calculate again?");
                    if(Console.ReadLine() == "no")
                    {
                        again = false;
                    }
                    else
                    {
                        again = true;
                    }
    
                }  while (again);
