    public class Range : INotifyPropertyChanged
    {
        // INPC impl omitted because this is c# like pseudocode
        public double StartTime {get;set;}
        public double EndTime {get;set;}
        public TimeSpan ToTimeSpan() { return YourConversionLogicLol(); }
    }
