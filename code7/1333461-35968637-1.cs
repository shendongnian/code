        struct item
        {
            private int iData;
            public item(int x)
            {
                this.iData = x;
            }
    
            public override string ToString()
            {
                return iData.ToString();
            }
    
        };
        class Program
        {
    
            static void Main(string[] args)
            {
                int Buffer_Size = 5;
                item[] buffer = new item[Buffer_Size];
                int inp = 0;
                int outp = 0;
    
                var console_lock = new object();
    
                new Thread(() =>
                {
                    item next_produced;
                    while (true)
                    {
                        lock (console_lock)
                        {
                            Console.WriteLine("Enter the next produced item");
                            int x = Convert.ToInt32(Console.ReadLine());
    
                            next_produced = new item(x);
                        }
                        while ((inp + 1) % Buffer_Size == outp) ;
                        // do nothing
                        buffer[inp] = next_produced;
                        inp = (inp + 1) % Buffer_Size;
    
                    }
                }).Start();
    
    
                new Thread(() =>
                {
                    item next_consumed = new item();
                    while (true)
                    {
                        while (inp == outp) ;
                        /*donothing*/
                        next_consumed = buffer[outp];
                        outp = (outp + 1) % Buffer_Size; /* consume the item in next consumed */
                        lock (console_lock) Console.WriteLine("Next consuumed item is: {0} ", next_consumed);
                    }
                }).Start();
    
                Thread.Sleep(Timeout.Infinite);
            }
        } 
