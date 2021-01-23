    static void Main(string[] args)
    {
        do
        {
            Console.Write("Number = ");
            string s = Console.ReadLine();
            int num = 0;
            bool inputOK = int.TryParse(s, out num);
            if (!inputOK || Math.Abs(num) == 0)
            {
                Console.WriteLine();
                Console.WriteLine("The input must be a non-zero integer in the range [{0} <= num <={1}]",int.MinValue,int.MinValue);
            }
            else
            {
                int n = Math.Abs(num);
                int numTrailingZeros = 0;
                bool check_ntz = true;
                int ndigits = GetSignificantDigits(n, ref check_ntz, ref numTrailingZeros);
                if (numTrailingZeros == 0)
                    Console.WriteLine("Number of signficant figures: {0}", ndigits);
                else
                    Console.WriteLine("Number of signficant figures: between {0} and {1}", ndigits, ndigits + numTrailingZeros);
            }
            Console.WriteLine();
            Console.WriteLine("Press ESC to terminate program, any other to continue.");
            Console.WriteLine();
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        return;
    }
    static int GetSignificantDigits(int n, ref bool check_ntz, ref int ntz)
    {
        if (n < 10)
            return 1;
        else
        {
            int new_n = (int)(n / 10);
            
            if (check_ntz)
            {
                if (n % 10 == 0)
                {
                    ntz++;
                    return GetSignificantDigits(new_n, ref check_ntz, ref ntz);
                }
                else
                {
                    check_ntz = false;
                    return 1 + GetSignificantDigits(new_n, ref check_ntz, ref ntz);
                }
            }
            else
                return 1 + GetSignificantDigits(new_n, ref check_ntz, ref ntz);
        }
    }
