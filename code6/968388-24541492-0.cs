            Stopwatch st = new Stopwatch();
            st.Start();
            while (true)
            {
                TimeSpan ts = st.Elapsed;
                string time = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                Console.Write("\r{0}     ", time);
                Thread.Sleep(1000);
            }
