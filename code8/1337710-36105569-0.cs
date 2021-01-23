    public enum Attendance
    {
        Yes,
        No,
        Maybe
    }
    public class Guest
    {
        ...
        public Attendance Attendance { get; set; } // raise PropertyChanged event if necessary
    }
