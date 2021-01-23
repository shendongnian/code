    static void Main(string[] args)
    {
        decimal hours;
        const decimal HOURLY_RATE = 2.5m;
        const decimal MAX_FEE = 20.00m;
        Console.WriteLine("Enter the amount of hours parked:");
        hours = decimal.Parse(Console.ReadLine());
        decimal parkingCost = hours * HOURLY_RATE;
        while (hours < 1 || hours > 24) 
        {
            Console.Write("Enter correct amount of hours - 1 to 24. ");
            hours = decimal.Parse(Console.ReadLine());
        }
        
        parkingCost = hours * HOURLY_RATE; // to recalculate
        if (parkingCost > MAX_FEE) 
        {
            Console.Write("Total fee is $" + MAX_FEE);
            Console.WriteLine(" Time parked in hours is " + hours);
        }
        else
        {
            parkingCost = hours * HOURLY_RATE;
            Console.WriteLine("The cost of parking is " + parkingCost.ToString("C"));
            Console.WriteLine("Time parked in hours is " + hours);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
