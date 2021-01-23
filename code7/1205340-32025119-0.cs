        double my_number;
        Console.WriteLine("Enter a number:");
        if (Double.TryParse(Console.ReadLine(), out my_number))
        {
                
        }
        else
        {
            Console.WriteLine("Error: Expected number.");
        }
        Console.ReadKey();
