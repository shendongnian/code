        public static void Count()
        {            
            Stopwatch s = new Stopwatch();
            int i = 0;
            s.Start();
            while (true)
            {
                if (s.ElapsedMilliseconds < i * 1000) { Thread.Sleep(10); continue; }
                i += 15; Console.Write(i + "  "); // or change i to 15 if you want the output to be '15' every time
            }
        }
