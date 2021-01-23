        int num1, num2, result;
    
        Console.WriteLine("Enter the first number to be the lower limit: ");
        num1 = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("Enter the second number to be the upper limit: \n");
        num2 = Convert.ToInt32(Console.ReadLine());
    
        while (num1 <= num2)
        {
            result = num1++ % 3;
    
            if (result == 0)
            {
                Console.WriteLine("{0} is divisible by 3.\n", num1 - 1);
            }
    
        }
        Console.ReadLine();
