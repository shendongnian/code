    List<DateTime> dtlist = new List<DateTime>();
    foreach (string time in timeList){
        DateTime dt = DateTime.ParseExact(x.time, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        dtlist.Add(dt);
    }
