            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Sort");
            dt.Rows.Add("TEST");
            dt.Rows.Add("TEST1");
            dt.Rows.Add("TEST2");
            var rnd = new Random(DateTime.Now.Millisecond);
            foreach (DataRow row in dt.Rows)
            {
                row["Sort"] = rnd.Next(dt.Rows.Count);
            }
            var dv = new DataView(dt);
            dv.Sort = "Sort";
            foreach (DataRowView row in dv)
            {
                Console.WriteLine(row[0]);
            }
