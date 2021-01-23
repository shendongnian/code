    public class AttendanceDisplayModel
    {
        //blablabla 
        public TimeSpan InTime { get; set; }
        public string InTimeFormatted{ get{ return InTime.ToString(@"hh\:mm\:ss"); } }
    }
    
