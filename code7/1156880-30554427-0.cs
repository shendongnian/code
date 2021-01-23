    try
    {
            Console.WriteLine("The number of lines you want to calculate up to");
            int loops = Convert.ToInt16(Console.ReadLine());
            if (loops < 0)
            {
                 Console.WriteLine("Can not enter a value less then zero... Try Again?");
                 Console.ReadLine();
                 goto Start;
            }
            Console.WriteLine("What multiplication tables would you like to do ?");
            int m = Convert.ToInt16(Console.ReadLine());
            for (int i = 1; i <= loops; i++)
            {
               Console.WriteLine(i * m); 
            }    
    }
    catch
    {
            Console.WriteLine("Enter numbers only");
            Console.ReadLine();
            goto Start;
    }
