        public static void WithRetry<T>(this Action action, int timeToWait = 500, int timesToRetry = 3) where T : Exception
        {
            var exceptions = new List<Exception>();
            for (int tryIndex = 0; tryIndex < timesToRetry; tryIndex++)
            {
                try
                {
                    action();
            
                    return;
                }
                catch (T t)
                {
                    exceptions.Add(t);
                }
                Thread.Sleep(timeToWait);
            }
            throw new AggregateException(exceptions);
        }
