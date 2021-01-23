            DataTable table = TwentyKRows();
            for (int i = 0; i < 4; i++)
            {
                DateTime before = DateTime.Now;
                var test = table.AsEnumerable().Skip(5000 * i).Take(5000);
                DateTime after = DateTime.Now;
                TimeSpan ts = after - before;
                Console.WriteLine(ts.ToString());
            }
