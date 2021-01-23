    static void Main(string[] args)
    {
            object oResouce1 = "-";
            object oResouce2 = "-";
            LockedResource lock1 = new LockedResource();
            LockedResource lock2 = new LockedResource();
            var h1 = new EventWaitHandle(false, EventResetMode.ManualReset);
            var h2 = new EventWaitHandle(false, EventResetMode.ManualReset);
            var h3 = new EventWaitHandle(false, EventResetMode.ManualReset);
            WaitHandle[] waitHandles = { h1, h2, h3 };
            var t1 = new Thread(() =>
            {
                lock1.DoWork(() =>
                {
                    oResouce1 = "1";
                    Console.WriteLine("Resource 1 set to 1");
                },"T1");
                h1.Set();
            });
                
            var t2 = new Thread(() =>
            {
                lock2.DoWork(() =>
                {
                    oResouce2 = "2";
                    Console.WriteLine("Resource 2 set to 2");
                    Thread.Sleep(10000);
                }, "T2");
                h2.Set();
            });
            var t3 = new Thread(() =>
            {
                lock1.DoWork(() =>
                {
                    oResouce1 = "3";
                    Console.WriteLine("Resource 1 set to 3");
                },  "T3");
                lock2.DoWork(() =>
                {
                    oResouce2 = "3";
                    Console.WriteLine("Resource 2 set to 3");
                }, "T3", 1000);
                h3.Set();
            });
            t1.Start();
            t2.Start();
            t3.Start();
            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine("Resouce 1 is {0}", oResouce1);
            Console.WriteLine("Resouce 2 is {0}", oResouce2);
            Console.ReadLine();
    }
