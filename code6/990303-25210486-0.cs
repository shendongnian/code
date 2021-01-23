                    lock (SyncVar)
                    {
                        bc = new BlockingCollection<Tuple<ChannelResource, string>>();
                        ProcessCall pc = new ProcessCall(OvrTelephonyServer, bc);
                        if (list.Count > 0)
                        {
                            Console.WriteLine("Block begin");
                            for (int i = 0; i < 4; i++)
                            {
                                if (list.Count > 0)
                                {
                                    var firstItem = list.FirstOrDefault();
                                    ChannelResource cr = OvrTelephonyServer.GetChannel();
                                    bc.TryAdd(Tuple.Create(cr, firstItem));
                                    list.Remove(firstItem);
                                }
                            }
                            bc.CompleteAdding();
                            pc.SimultaneousCall();
                            Console.WriteLine("Blocking end");
                        }
                        if (ThreadState != State.Running) break;
                    }
