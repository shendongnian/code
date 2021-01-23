        private static void DoSomeTask(int RetryCount)
        {
            int Count = 0;
            while (Count != RetryCount)
            {
                DoCustomerLookUp(); // or whatever you want to do
                Count++;
            }
        }
