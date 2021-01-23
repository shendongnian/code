        static void Main(string[] args)
        {
            do
            {
                Console.Write("Input a number: ");
                uint input = uint.Parse(Console.ReadLine());
                CalculateK(input);
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }
        static void CalculateK(uint nCount)
        {
            uint kSum = 0;
            double kCalc = 0;
            double k = 1;
            for (int j = 1; j <= nCount; j++)
            {
                kCalc = Convert.ToUInt32(Math.Ceiling((1000) * Math.Pow(Math.E, -k / 20)));
                Console.Write("{0,2}. {1,3} ", j, kCalc);
                if(j % 4 == 0)
                {
                    Console.WriteLine(); // If the counter is divisible by 4 then add a new line.
                }
                kSum += Convert.ToUInt32(kCalc);
                k++;
            }
            Console.WriteLine();
            Console.WriteLine("Sum = {0}", kSum.ToString("0,0")); // Use the ToString method and add your desired format instead.
        }
