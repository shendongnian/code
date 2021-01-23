     using (var muxer = ConnectionMultiplexer.Connect("localhost,resolvedns=1"))
            {
                muxer.PreserveAsyncOrder = preserveOrder;
                RedisKey key = "MBOA";
                var conn = muxer.GetDatabase();
                muxer.Wait(conn.PingAsync());
                Action<Task> nonTrivial = delegate
                {
                    Thread.SpinWait(5);
                };
                var watch = Stopwatch.StartNew();
                for (int i = 0; i <= AsyncOpsQty; i++)
                {
                    var t = conn.StringSetAsync(key, i);
                    if (withContinuation) t.ContinueWith(nonTrivial);
                }
                int val = (int)muxer.Wait(conn.StringGetAsync(key));
                watch.Stop();
                Console.WriteLine("After {0}: {1}", AsyncOpsQty, val);
                Console.WriteLine("({3}, {4})\r\n{2}: Time for {0} ops: {1}ms; ops/s: {5}", AsyncOpsQty, watch.ElapsedMilliseconds, Me(),
                    withContinuation ? "with continuation" : "no continuation", preserveOrder ? "preserve order" : "any order",
                    AsyncOpsQty / watch.Elapsed.TotalSeconds);
            }
