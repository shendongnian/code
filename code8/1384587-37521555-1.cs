    static void Main(string[] args)
    {
            bool bSuccess1 = false;
            bool bSuccess2 = false;
            LockedResource resource1 = new LockedResource(() => {
                bSuccess1 = true;
                return true;
            });
            LockedResource resource2 = new LockedResource(() =>
            {
                bSuccess2 = true;
                Console.WriteLine("Resource 1 is {0}", bSuccess1);
                Console.WriteLine("Resource 2 is {0}", bSuccess2);
                return true;
            });
            
            var t1=new Thread(()=>{
                resource1.DoWork("T1");
                Console.WriteLine("Resource 1 is {0}", bSuccess1);
                Console.WriteLine("Resource 2 is {0}", bSuccess2);
                Thread.Sleep(1000);
            });
            
            var t2 = new Thread(() =>
            {
                resource2.DoWork("T2");
                Console.WriteLine("Resource 1 is {0}", bSuccess1);
                Console.WriteLine("Resource 2 is {0}", bSuccess2);
                Thread.Sleep(2000);
            });
            var t3 = new Thread(() =>
            {
                resource1.DoWork("T3");
                resource2.DoWork("T3");
                Console.WriteLine("Resource 1 is {0}", bSuccess1);
                Console.WriteLine("Resource 2 is {0}", bSuccess2);
            });
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadLine();
    }
