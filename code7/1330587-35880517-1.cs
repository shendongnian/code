        public T CheckFunctionWithTrials<T>(Func<T> X)
        {
            foreach (var i in Enumerable.Range(1, 5))
            {
                try
                {
                    return X();
                }
                catch (Exception e)
                {
                    if (i == 5)
                    {
                        throw;
                    }
                    else
                    {
                        //DLog.Warn("Failed to upload file. Retry #" + (i) + ": " + path);
                        Thread.Sleep(1000);
                    }
                }
            }
        }
