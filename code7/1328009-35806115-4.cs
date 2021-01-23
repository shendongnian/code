    public class Student
    {
        public DateTime WeekOfAssignment { get; set; }
        public int TalkType { get; set; }
        public int StudentID_FK { get; set; }
        public int AssistantID_FK { get; set; }
        public int CounselPoint { get; set; }
        public bool HasBeenEmailed { get; set; }
        public bool SlipHasBeenPrinted { get; set; }
    }
