        static void Main(string[] args)
        {
            System.Threading.Timer timer = null;
            int counts = 0;
            timer = new Timer((obj) =>
            {
                Console.WriteLine(counts);
                if (++counts > 10)
                    timer.Dispose();
            }, null, 100, 100);
            for (;;) ;
        }
