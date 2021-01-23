    public class ButtonModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ButtonModel(DateTime _startDate, DateTime _endDate)
        {
            StartDate = _startDate;
            EndDate = _endDate;
        }
        public string StartDateTruncatedName
        {
            get { return StartDate.ToString("dddd").Substring(0, 3).ToUpper(); }
        }
        public string StartDateDayNum
        {
            get { return StartDate.Day.ToString(); }
        }
        public string StartDateMonth
        {
            get { return StartDate.ToString("MMMM").ToUpper(); }
        }
    }
