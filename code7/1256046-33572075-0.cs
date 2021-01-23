        static Random randomObject = new Random();
        static void Main(string[] args)
        {
            int MAX_NUMBER = 10;
            int MIN_NUMBER = 1;
            int NUMBER_OF_RESULTS_REQUIRED = 5;
            long[] randomArr = new long[NUMBER_OF_RESULTS_REQUIRED];
            //Use a pool of all possible values
            List<long> dataSet = new List<long>();
            for (int i = MIN_NUMBER; i <= MAX_NUMBER; ++i)
            {
                dataSet.Add(i);
            }
            for (int i = 0; i < NUMBER_OF_RESULTS_REQUIRED; ++i)
            {
                int t = randomObject.Next(0, dataSet.Count);
                randomArr[i] = dataSet[t];
                dataSet.RemoveAt(t);
            }
            for (int i = 0; i < randomArr.Length; ++i)
            {
                Console.WriteLine(randomArr[i]);
            }
            Console.ReadKey();
        }
