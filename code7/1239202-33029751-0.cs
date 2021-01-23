        static void Main(string[] args)
        {
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("date", typeof(DateTime));
            for (int i = 0; i < 10; ++i)
            {
                var r = dt.NewRow();
                r[0] = i;
                r[1] = DateTime.Now.AddMinutes(-i);
                dt.Rows.Add(r);
            }
            foreach (var r in dt.Rows.OfType<DataRow>())
            {
                Console.WriteLine("{0} - {1:yyyy-MM-dd HH:mm:ss.fff}", r[0], r[1]);
            }
            Console.ReadLine();
        }
