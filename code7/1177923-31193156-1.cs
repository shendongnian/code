    using System;
    class CreditScores
    {
        static void Main()
        {            
            double total = 0;
            int sum = 0;        
            int count = 0; 
            Console.WriteLine("Enter value between 300 to 850.");
            int first = int.Parse(Console.ReadLine());
    
            //trying to get it to stop when sentihel value reached.
            for (iterations = 0; iterations < 1000; iterations++)
            {
                Console.WriteLine("Enter value between 300 to 850.");
                int input;
                // Check number is integer
                if (int.TryParse(Console.ReadLine(), out input)
                {
                    if(input > 300 && input < 850)
                    {
                        total +=input;
                    }
                }    
                else
                {
                    break;  
                }
    
                count++;
            }
            total = sum + total;
            Console.WriteLine("Total is {0}", total);
    
            double average = total/count;
            Console.WriteLine("The average is {0}", average);
            Console.ReadLine(); // Either this or run with Ctrl-F5
        }    
    }
    
