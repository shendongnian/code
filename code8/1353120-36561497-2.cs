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
    
    
        if (Freebie > Buy || Freebie >= Wrap) // 2 > 8 || 2 >= 4 *FALSE*
        {
            Console.WriteLine("COMPANY GOES BANKRUPT");
            Console.ReadLine();
        }
    
        else
        {
            TotalFreebie = (Buy/Wrap)*Freebie; // (8/4)*2 = 4
    
            WrapsLeft = Buy%Wrap + TotalFreebie; = 8%4 + 4 = 0+4 = 4
            
            while(WrapsLeft >= Wrap) // 4>=4 *TRUE* // 2>=4 *FALSE*
            {
                TotalFreebie += (WrapsLeft/Wrap)*Freebie; // 4 + (4/4)*2 = 4 + 2 = 6
                WrapsLeft = (WrapsLeft/Wrap)*Freebie; // (4/4)*2 = 2
            }            
       
            Eaten = Buy + TotalFreebie; // 8+6 = 14
    
            Console.WriteLine("{0} {1}", Eaten, WrapsLeft); // 14 2
            Console.ReadLine();
        }
    }
