    public class AttendanceDisplayModel
    {
        //blablabla 
        public TimeSpan Late { get; set; }
        public string LateFormatted{ get{ return Late.ToString(@"hh\:mm\:ss"); } }
    }
    
