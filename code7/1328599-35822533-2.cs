    public static partial class Program
    {
        const int pkgprice = 99;   // Software package price
        static int SFTWR = 0;      // number of software packages purchased
        static int Total = 0;      // Total price of sale after discounts applied
    
        static void Main()
        {
            {//software packages purchased
                Console.WriteLine("How many software packages are you purchasing?");
    
                while (!int.TryParse(Console.ReadLine(), out SFTWR) || SFTWR <= 0)
                    Console.WriteLine("INVALID PLEASE ENTER A VALID NUMBER");
    
            }//end software packages purchased
    
            if (SFTWR <= 9)
            {
                Console.WriteLine("Your total is {0}. No discounts were applied due the low volume of the order", Total = SFTWR * pkgprice);
            }
        }
    }
