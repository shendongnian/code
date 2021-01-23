            // Allow concurrency
            for (int i = 0; i < 10000000; i++)
            {
                // All threads increment the value
                int currentState = Interlocked.Increment(ref _state);
                if (currentState == 4)
                {
                    // But still, only one thread at a time enters this branch
                    // Allow race condition on purpose (it may actually happen here)
                    currentState = Interlocked.CompareExchange(ref _state, 0, 0);
                    if (currentState != 4)
                    {
                        // This branch might be taken with a maximum value of 3 + N
                        Console.Write(currentState);
                    }
                }
                Interlocked.Decrement(ref _state);
            }
