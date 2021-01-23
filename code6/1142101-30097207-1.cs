    class YourClass
    {
        public int OtherID { get; set; }
        public int DayID { get; set; }
    }
    var getQ = db.Requests.Where(x => temp.Contains(x.carID))
                          .Select(x => new YourClass { OtherID = x.otherID, DayID = x.dayID).ToList();
