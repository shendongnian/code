    public class AttendanceDisplayModel
    {
        //blablabla 
        public int Late { get; set; }
        public string Late Formatted{ get{ return new TimeSpan((double)Late ).ToString(@"hh\:mm\:ss"); } }
    }
