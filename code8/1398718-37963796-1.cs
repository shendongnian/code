     public static void Example()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Signal", typeof(int));
        dt.Columns.Add("Date", typeof(DateTime));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-02 11:23:25", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-02 18:24:03", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-03 05:38:49", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(0, DateTime.ParseExact("2015-03-03 08:47:02", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-03 14:01:31", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-03 21:11:53", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(1, DateTime.ParseExact("2015-03-04 09:34:04", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(0, DateTime.ParseExact("2015-03-04 15:29:27", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        dt.Rows.Add(0, DateTime.ParseExact("2015-03-04 19:28:33", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture));
        var groups = dt.AsEnumerable().GroupBy(r => (int)r["Signal"]);
        foreach (var group in groups)
        {
            int groupMinutes = 0;
            var datesDescending = group.OrderByDescending(g => g["Date"]);
            for (int i = 0; i < datesDescending.Count(); i += 2)
            {
                var date1 = (DateTime)datesDescending.ElementAt(i)["Date"];
                if (datesDescending.Count() > i + 1)
                {
                    var date2 = (DateTime)datesDescending.ElementAt(i + 1)["Date"];
                    var dateOffset = date1.Subtract(date2);
                    groupMinutes += dateOffset.Hours * 60 + dateOffset.Minutes;
                }
                else
                    groupMinutes += date1.Hour * 60 + date1.Minute;
            }
            Console.WriteLine("Signal: {0}, total minutes: {1}", group.Key, groupMinutes);
        }
    }
