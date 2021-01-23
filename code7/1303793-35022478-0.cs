        static void Main(string[] args)
        {
            while (true)
            {
                string s = Console.ReadLine();
                BigInteger l;
                if (BigInteger.TryParse(s, out l))
                    Console.WriteLine(Getmultiple(l));
                else
                    Console.WriteLine("Not a valid integer");
            }
        }
        private static BigInteger Getmultiple(BigInteger n)
        {
            for (BigInteger i = 1; ; i++)
            {
                String binary = Convert.ToString((long) i, 2);
                BigInteger no = BigInteger.Parse(binary);
                if (no % n == 0)
                {
                    return no;
                }
            }
        }
