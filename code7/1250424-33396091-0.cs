     class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Service1)))
            {
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(delegate
                {
                    while (true)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(100));
                        QueueDummyIOCPWork();
                    }
                }));
                host.Open();
                Console.WriteLine("Service running...");
                Console.ReadKey(false);
            }
        }
        private static unsafe void QueueDummyIOCPWork()
        {
            Overlapped ovl = new Overlapped();
            NativeOverlapped* pOvl = null;
            pOvl = ovl.Pack((a, b, c) => { Overlapped.Unpack(pOvl); Overlapped.Free(pOvl); }, null);
            ThreadPool.UnsafeQueueNativeOverlapped(pOvl);
        }
    }
