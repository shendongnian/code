        static void Main(string[] args)
        {
            double RateActing = -1;
            double RateMusic = -1;
            do
            {
                Console.WriteLine("\n \t Rate the Acting on a scale of 0 to 5");
                double.TryParse(Console.ReadLine(), out RateActing);
            }
            while (RateActing < 0 || RateActing > 5);
            Console.WriteLine("\n you have rated the action of the movie {0}", RateActing);
            do
            {
                Console.WriteLine("\n \t Rate the music of the movie on a scale of 0 to 5");
                double.TryParse(Console.ReadLine(), out RateMusic);
            }
            while (RateMusic < 0 || RateMusic > 5);
            Console.WriteLine("\n you have rated the music of the movie {0}", RateMusic);
            double totrate = getoverallRate(RateActing, RateMusic);
            Console.WriteLine("total rate is {0}", totrate);
            Console.ReadKey();
        }
        public static double getoverallRate(double rateact, double ratemus)
        {
            rateact *= 0.25;
            ratemus *= 0.15;
            return rateact + ratemus;
        }
