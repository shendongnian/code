        static void Main(string[] args)
        {
            // 76576500
            long age = 10000;
            double alpha = 1.5;
            double betta = 0.1;
            Random ran = new Random();
            long mmm = long.MaxValue;
            double RR = 0;
            var a = DateTime.Now;
            for (int i = 0; i < 5000; i++)
            {
                long N = age * (age + 1) / 2;
                long count = 0;
                for (int j = 2; N!=1; j++)
                {
                    int c = 0;
                    while (N % j == 0)
                    {
                        N /= j;
                        c++;
                    }
                    count = (count + 1) * (c + 1) - 1;
                }
                double r = ran.Next() % 11;
                r = 1 / (Math.Pow(r, alpha) + 1);
                long R = (long)r + 1;
                if (count >= 500)
                {
                    alpha *= 1 + 0.001;
                    RR = RR * betta - (1-betta) * R;
                    N = age * (age + 1) / 2;
                    if (N < mmm)
                    {
                        mmm = N;
                        Console.WriteLine(mmm);
                    }
                }
                else
                {
                    alpha *= 1 - 0.001;
                    RR = RR * betta + (1 - betta) * R;
                }
                age += (long)RR;
            }
            var b = DateTime.Now - a;
            Console.WriteLine("R=" + mmm + "  " + b);
            string sss = Console.ReadLine();
        }
