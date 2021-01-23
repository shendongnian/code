    public class AttendanceDisplayModel
    {
        //blablabla 
        public TimeSpan Late { get; set; }
        public string Late Formatted{ get{ return Late.ToString(@"hh\:mm\:ss"); } }
    }
    
