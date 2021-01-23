            // Do not allow concurrency, non-blocking
            for (int i = 0; i < 10000000; i++)
            {
                // Only one thread at a time will succeed in exchanging the value
                try
                {
                    int previousState = Interlocked.CompareExchange(ref _state, 4, 3);
                    if (previousState == 3)
                    {
                        // Allow race condition on purpose (for no reason)
                        int currentState = Interlocked.CompareExchange(ref _state, 0, 0);
                        if (currentState != 4)
                        {
                            // This branch is never taken
                            Console.Write(currentState);
                        }
                    }
                }
                finally
                {
                    Interlocked.CompareExchange(ref _state, 3, 4);
                }
            }
