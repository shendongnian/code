    static void dailyspend(ref double totalspendf, ref double totalspendc, ref double totalspendcr, ref double totalspendo)
    { 
        int days;
        double spendf = 0, spendc = 0, spendcr = 0, spendo = 0;
        for (days = 1; days <= 7; days++)
        {
            Console.WriteLine("");
            Console.Write("Food : ");
            spendf = double.Parse(Console.ReadLine());
            Console.Write("Clothing : ");
            spendc = double.Parse(Console.ReadLine());
            Console.Write("College related : ");
            spendcr = double.Parse(Console.ReadLine());
            Console.Write("Outside: ");
            spendo = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            totalspendf += spendf;
            totalspendc += spendc;
            totalspendcr += spendcr;
            totalspendo += spendo;
        }
    }
