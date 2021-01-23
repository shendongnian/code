    public class myWeeklyObject
    {
        public myWeeklyObject()
        { }
        public int ObjectID { get; set; }
        public int WeekNo { get; set; }
        public Dictionary<int, myDataObject> DataByDay { get; set; }
    }
    public class myDataObject
    {
        //Other variables can go here.
    }
