        static void Main(string[] args)
        {
            Thread th = new Thread(prnt);
            th.Start();
            for (int i = 0; i < 10; i++)
            {
                //sleep one second
                Thread.Sleep(1000);
                Console.WriteLine(i + "A");
            }
            //join the basic thread and 'th' thread 
            th.Join();
        }
        private static void prnt()
        {
            for (int i = 0; i < 10; i++)
            {
                //sleep one second
                Thread.Sleep(1000);
                Console.WriteLine(i + "B");
            }
        }
