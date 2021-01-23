    static void dailyspend(ref double totalspendf, ref double totalspendc, ref double totalspendcr, ref double totalspendo)
    { 
        int days;
        for (days = 1; days <= 7; days++)
        {
            Console.WriteLine("");
            Console.Write("Food : ");
            double spendf = double.Parse(Console.ReadLine());
            Console.Write("Clothing : ");
            double spendc = double.Parse(Console.ReadLine());
            Console.Write("College related : ");
            double spendcr = double.Parse(Console.ReadLine());
            Console.Write("Outside: ");
            double spendo = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            totalspendf += spendf;
            totalspendc += spendc;
            totalspendcr += spendcr;
            totalspendo += spendo;
        }
    }
