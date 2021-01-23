            StringBuilder sb = new StringBuilder();
            string st;
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            for (int i = 0 ; i < 100000 ; i++)
            {
                sb.Append("a");
            }
            st = sb.ToString();
            sw.Stop();
            Debug.WriteLine($"Elapsed: {sw.Elapsed}");
            st = "";
            sw = Stopwatch.StartNew();
            for (int i = 0 ; i < 100000 ; i++)
            {
                st = st + "a";
            }
            sw.Stop();
            Debug.WriteLine($"Elapsed: {sw.Elapsed}");
