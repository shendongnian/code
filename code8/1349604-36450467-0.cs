    //This class will store the given month information
    class MonthInfo
    {
        public DayOfWeek DayName { get; set; }
        public DateTime DayDate { get; set; }
    }
    //This class will store the cursor position, just to make it look like a calendar
    class CursorPosition
    {
        public string DayName { get; set; }
        public DayOfWeek DayWeek { get; set; }
        public int locationx { get; set; }
    
    }
