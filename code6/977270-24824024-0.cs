        public static void StartTimer()
        {
            while (true)
            {
                UpdateTime();
                Thread.Sleep(1000);
            }
        }
