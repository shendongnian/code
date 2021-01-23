    static void Main(string[] args)
    {
        const double balance = 303.91;
        const double phonePrice = 99.99;
        double a = 0;
        // You don't want to run out of money, so check if buying 
        // another phone will bankrupt your finances....
        while ((a + phonePrice) < balance )
        {
            a = a + phonePrice; 
        }
        Console.WriteLine(a); // a = 299,97
        Console.ReadLine();
    }
