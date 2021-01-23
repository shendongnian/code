        public void CheckFunctionWithTrials(Action X)
        {
            foreach (var i in Enumerable.Range(1, 5))
            {
                try
                {
                    X?.Invoke();
                    break;
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
