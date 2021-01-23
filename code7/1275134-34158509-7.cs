     static void Main(string[] args)
        {
            var mySlow = new SlowClass();
            var mySlow2 = new SlowClass();
            mySlow.GetCachedData();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                mySlow.GetData();
                mySlow2.GetData();
            }
            mySlow.GetCachedData();
            Console.Read();
        }
