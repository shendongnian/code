        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[] 
        {
            new DataColumn("Date",typeof(DateTime)),
            new DataColumn("Location",typeof(string)),
        });
        dt.Rows.Add(DateTime.ParseExact("23/07/2014 10:30", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "Near Highway");
        dt.Rows.Add(DateTime.ParseExact("23/07/2014 11:30", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "Near Highway");
        dt.Rows.Add(DateTime.ParseExact("23/07/2014 12:30", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "Near Highway");
        dt.Rows.Add(DateTime.ParseExact("24/07/2014 01:00", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "From Texas");
        dt.Rows.Add(DateTime.ParseExact("24/07/2014 01:10", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "From Texas");
        dt.Rows.Add(DateTime.ParseExact("24/07/2014 01:20", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "From Texas");
        dt.Rows.Add(DateTime.ParseExact("24/07/2014 01:30", "dd/MM/yyyy HH:mm", new CultureInfo("fr-fr")), "From Texas");
        DataTable dt2 = new DataTable();
        dt2.Columns.AddRange(new DataColumn[] 
        {
            new DataColumn("Date"),
            new DataColumn("Start time"),
            new DataColumn("End time"),
            new DataColumn("Duration"),
            new DataColumn("Location")
        });
        var groups = dt.AsEnumerable().GroupBy(row => row["Location"]);
        foreach (var group in groups)
        {
            Console.WriteLine(group.Key);
            var groups2 = group.OrderBy(row => row["Date"]).GroupBy(row => Convert.ToDateTime(row["Date"]).ToString("dd/MM/yyyy"));
            foreach (var group2 in groups2)
            {
                Console.WriteLine("\t" + group2.Key);
                var list = group2.ToList();
                var startDate = Convert.ToDateTime(list[0]["Date"]);
                var endDate = Convert.ToDateTime(list[list.Count-1]["Date"]);
                TimeSpan ts = endDate-startDate;
                dt2.Rows.Add(group2.Key, startDate.ToString("HH:mm"), endDate.ToString("HH:mm"), ts.Hours + " hour " + ts.Minutes + " minutes", group.Key);
            }
        }
