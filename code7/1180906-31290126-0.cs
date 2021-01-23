        public static void timer()
        {            
            Stopwatch s = new Stopwatch();
            int i = 0;
            s.Start();
            while (true)
            {
                if (s.ElapsedMilliseconds % 15000 != 0) continue;
                Console.Write("15  "); Thread.Sleep(10);               
            }
        }
