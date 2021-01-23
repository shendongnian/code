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
