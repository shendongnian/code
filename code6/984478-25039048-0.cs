     DataTable dt = new DataTable();
     dt.Columns.Add("TotalTime", typeof(string));
     dt.Rows.Add("00:05:44");
     dt.Rows.Add("00:10:25");
     dt.Rows.Add("00:20:15");
     var average = TimeSpan.FromTicks((long)(dt.AsEnumerable()
                .Select(row => TimeSpan.Parse(row.Field<string>("TotalTime")))
                .Average(ts => ts.Ticks)));
     //00:12:08
