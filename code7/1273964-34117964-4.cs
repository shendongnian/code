    List<ParkTime> parktimes = new List<ParkTime>();
    foreach (string line in File.ReadLines("file.txt"))
    {
        bool isValid = true;
        string[] times = line.Split(',');  
        DateTime dtInit;
        if(!DateTime.TryParseExact(times[0].Trim(), "HH:mm", 
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.NoCurrentDateDefault,
            out dtInit))
            isValid = false;
        DateTime dtEnd;
        if (!DateTime.TryParseExact(times[1].Trim(), "HH:mm",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.NoCurrentDateDefault,
            out dtEnd))
            isValid = false;
        if (isValid)
            parktimes.Add(new ParkTime() { startTime = dtInit, endTime = dtEnd });
    }
    public struct ParkTime
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
