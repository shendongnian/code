    public struct RetryPolicy<T>
    {
        private int mRetryMax;
        private int mRetryWaitSec;
    
        public RetryPolicy(int retryMax, int retryWaitSec)
        {
            mRetryMax = retryMax;
            mRetryWaitSec = retryWaitSec;
        }
    
        public T DoWork(System.Func<T> func)
        {
            int retries = 0;
    
            while (true)
            {
                try
                {
                    return func();
                }
                catch when (++retries < RetryMax)
                {
                    Thread.Sleep(RetryWaitSec * 1000);
                }
            }
        }
    
        public int RetryMax
        {
            get
            {
                return mRetryMax;
            }
        }
    
        public int RetryWaitSec
        {
            get
            {
                return mRetryWaitSec;
            }
    
            set
            {
                mRetryWaitSec = value;
            }
        }
    }
