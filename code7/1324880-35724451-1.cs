    using StackExchange.Redis;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    static class P
    {
        static void Main()
        {
            Console.WriteLine("Connecting to server...");
            using (var muxer = ConnectionMultiplexer.Connect("127.0.0.1"))
            {
                Console.WriteLine("Connected");
                var db = muxer.GetDatabase();
                
                RedisKey key = "some key";
                byte[] payload = new byte[3];
                new Random(12345).NextBytes(payload);
                RedisValue value = payload;
                DoWork("PING (sync per op)", db, 1000000, 50, x => { x.Ping(); return null; });
                DoWork("SET (sync per op)", db, 500000, 50, x => { x.StringSet(key, value); return null; });
                DoWork("GET (sync per op)", db, 500000, 50, x => { x.StringGet(key); return null; });
    
                DoWork("PING (pipelined per thread)", db, 1000000, 50, x => x.PingAsync());
                DoWork("SET (pipelined per thread)", db, 500000, 50, x => x.StringSetAsync(key, value));
                DoWork("GET (pipelined per thread)", db, 500000, 50, x => x.StringGetAsync(key));
            }
        }
        static void DoWork(string action, IDatabase db, int count, int threads, Func<IDatabase, Task> op)
        {
            object startup = new object(), shutdown = new object();
            int activeThreads = 0, outstandingOps = count;
            Stopwatch sw = default(Stopwatch);
            var threadStart = new ThreadStart(() =>
            {
                lock(startup)
                {
                    if(++activeThreads == threads)
                    {
                        sw = Stopwatch.StartNew();
                        Monitor.PulseAll(startup);
                    }
                    else
                    {
                        Monitor.Wait(startup);
                    }
                }
                Task final = null;
                while (Interlocked.Decrement(ref outstandingOps) >= 0)
                {
                    final = op(db);
                }
                if (final != null) final.Wait();
                lock(shutdown)
                {
                    if (--activeThreads == 0)
                    {
                        sw.Stop();
                        Monitor.PulseAll(shutdown);
                    }
                }
            });
            lock (shutdown)
            {
                for (int i = 0; i < threads; i++)
                {
                    new Thread(threadStart).Start();
                }
                Monitor.Wait(shutdown);
                Console.WriteLine($@"{action}
        {sw.ElapsedMilliseconds}ms for {count} ops on {threads} threads
        {(count * 1000) / sw.ElapsedMilliseconds} ops/s");
            }
        }
    }
