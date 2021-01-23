                while (!cts.Token.IsCancellationRequested)
                {
                    //No command before the barrier
                    Thread.MemoryBarrier();
                    //Can end up on this side of the barrier  
                    // critical part
                    var readState = state;
                    // use it
                    if (readState != null)
                    {
                        Console.WriteLine(readState.Current);
                        Console.WriteLine(readState.Str);
                        Console.WriteLine(readState.X);
                    }
                }
