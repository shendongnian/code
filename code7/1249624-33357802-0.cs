    public static double GetPosNonZeroDouble()
    { 
        double x = 0;
    
        while (x <= 0)
        {
            Console.WriteLine("Enter The Length Of The Side");
            if (!double.TryParse(Console.ReadLine(), x) || x <= 0)
            {
                Console.WriteLine("Error - input must be a non - zero positive number");
            }
        }
        return x;
     }
