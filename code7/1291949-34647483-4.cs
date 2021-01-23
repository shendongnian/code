    List<string> timeList = lst.Select(x => x.time).ToList(); //Step 1
    List<DateTime> dtlist = new List<DateTime>(); //Step 2-3
    foreach (string time in timeList){
        DateTime dt = DateTime.ParseExact(x.time, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        dtlist.Add(dt);
    }
    DateTime biggest = dtlist.Max(); //Step 4
