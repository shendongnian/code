    //For 4 Wraps get 2 Freebies, Buy 8 = 13 Eaten and 5 WrapLeft (should be 14 Eaten and 2 WrapsLeft).
    static void Main(string[] args)
    {
        int Wrap = 0;
        int Freebie = 0;
        int TotalFreebie = 0;
        int Buy = 0;
        int Increment = 0;
        int Eaten = 0;
        int WrapsLeft = 0;
        Console.WriteLine("Introduce amount of wraps");
        Wrap = Int32.Parse(Console.ReadLine()); // 4
        Console.WriteLine("Introduce number of freebies per wrap");
        Freebie = Int32.Parse(Console.ReadLine()); // 2
        Console.WriteLine("Introduce amount of candy bought");
        Buy = Int32.Parse(Console.ReadLine()); // 8
        TotalFreebie = (Buy / Wrap) * Freebie; // 8/4*2 = 4
        Eaten = Buy + TotalFreebie; // 8+4 = 12
        WrapsLeft = Eaten - Buy; 12-8 = 4
        if (Freebie > Buy || Freebie >= Wrap) // 2 > 8 || 2 >= 4 *FALSE*
        {
            Console.WriteLine("COMPANY GOES BANKRUPT");
            Console.ReadLine();
        }
        else
        {
            if (TotalFreebie > Wrap) // 4 > 4 *TRUE*
            {
                do
                {
                    TotalFreebie = (Buy / Wrap) * Freebie;
                    Increment = TotalFreebie / Wrap;
                    Increment++;
                    Eaten = Buy + TotalFreebie + Increment;
                    WrapsLeft = Eaten - (Buy + TotalFreebie);
                } while (TotalFreebie > Wrap);
            }
            else 
            {
                if (TotalFreebie == Wrap && Buy > Wrap) // 4 == 4 && 8 > 4 *TRUE*
                {
                    TotalFreebie = (Buy / Wrap) * Frebie; // 8/4*2 = 4
                    Eaten = Buy + TotalFreebie + Freebie; // 8+4+2 = 14
                    WrapsLeft = Eaten - (Buy + TotalFreebie); // 14-(8+4) = 2
                }
                else 
                {
                    TotalFreebie = (Buy / Wrap) * Freebie;
                    Eaten = Buy + TotalFreebie;
                    WrapsLeft = Eaten - Buy;
                }
            }
            TotalFreebie = (Buy / Wrap) * Freebie; // 8/4*2 = 4
            Eaten = Buy + TotalFreebie + (TotalFreebie/Wrap); // 8+4+(4/4) = 13 
            if (TotalFreebie>Wrap) // 4>4 *FALSE*
            {
                WrapsLeft = Eaten - (Buy + TotalFreebie);
            }
            else
            {
                WrapsLeft = Eaten - Buy; // 13-8 = 5 
            }
            Console.WriteLine("{0} {1}", Eaten, WrapsLeft); // 13 5
            Console.ReadLine();
        }
    }
