                    foreach (TraceListener listener in TraceInternal.Listeners)
                    {
                        if (listener.IsThreadSafe)
                        {
                            listener.WriteLine(message);
                            if (!TraceInternal.AutoFlush)
                            {
                                continue;
                            }
                            listener.Flush();
                        }
                        else
                        {
                            lock (listener)
                            {
                                listener.WriteLine(message);
                                if (TraceInternal.AutoFlush)
                                {
                                    listener.Flush();
                                }
                            }
                        }
                    }
