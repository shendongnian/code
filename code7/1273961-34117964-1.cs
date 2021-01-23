    List<ParkTime> parktimes = new List<ParkTime>();
    string temp = "10:25, 10:55\r\n11:05, 11:50\r\n12:20, 13:10";
    foreach (string s in temp.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
    {
        bool isValid = true;
        DateTime dtInit;
        if(!DateTime.TryParseExact(times[0].Trim(), "hh:mm", 
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.NoCurrentDateDefault,
            out dtInit))
            isValid = false;
        DateTime dtEnd;
        if (!DateTime.TryParseExact(times[1].Trim(), "hh:mm",
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
