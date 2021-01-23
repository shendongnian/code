    public class AttendanceDisplayModel
    {
        //blablabla 
        public int Late { get; set; }
        public string LateFormatted{ get{ return new TimeSpan((double)Late ).ToString(@"hh\:mm\:ss"); } }
    }
