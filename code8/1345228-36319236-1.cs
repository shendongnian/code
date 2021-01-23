    public class CalendarFile
    {
        private CfStatus _status = CfStatus.Busy;
        private string _location = "";
        private string _description = "";
    
        public CalendarFile(string title, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Attept to initialize a calendar event with start date after end date");
    
            Summary = title;
            StartDate = startDate;
            EndDate = endDate;
        }
    
        public enum CfStatus { Free, Busy, Tentative, OutOfTheOffice };
    
        override public string ToString()
        {
            var calEvent = new StringBuilder();
            calEvent.AppendLine("BEGIN:VCALENDAR");
            calEvent.AppendLine("VERSION:2.0");
            calEvent.AppendLine("BEGIN:VEVENT");
    
            switch (Status)
            {
                case CfStatus.Busy:
                    calEvent.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:BUSY");
                    break;
                case CfStatus.Free:
                    calEvent.AppendLine("TRANSP:TRANSPARENT");
                    break;
                case CfStatus.Tentative:
                    calEvent.AppendLine("STATUS:TENTATIVE");
                    break;
                case CfStatus.OutOfTheOffice:
                    calEvent.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:OOF");
                    break;
                default:
                    throw new Exception("Invalid CFStatus");
            }
    
            if (AllDayEvent)
            {
                calEvent.AppendLine("DTSTART;VALUE=DATE:" + ToCFDateOnlyString(StartDate));
                calEvent.AppendLine("DTEND;;VALUE=DATE:" + ToCFDateOnlyString(EndDate));
            }
            else
            {
                calEvent.AppendLine("DTSTART:" + ToCFString(StartDate));
                calEvent.AppendLine("DTEND:" + ToCFString(EndDate));
            }
    
            calEvent.AppendLine("SUMMARY;ENCODING=QUOTED-PRINTABLE:" + ToOneLineString(Summary));
    
            if (Location != "") calEvent.AppendLine("LOCATION;ENCODING=QUOTED-PRINTABLE:" + ToOneLineString(Location));
            if (Description != "") calEvent.AppendLine("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" + ToCFString(Description));
    
            calEvent.AppendLine("END:VEVENT");
            calEvent.AppendLine("END:VCALENDAR");
    
            return calEvent.ToString();
        }
    
        public string Summary { get; set; }
    
        public DateTime StartDate { get; private set; }
    
        public DateTime EndDate { get; private set; }
    
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
    
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    
        public bool AllDayEvent { get; set; }
    
        public CfStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
    
        private static string ToCFString(DateTime val)
        {
            //format: YYYYMMDDThhmmssZ where YYYY = year, MM = month, DD = date, T = start of time character, hh = hours, mm = minutes,
            //ss = seconds, Z = end of tag character. The entire tag uses Greenwich Mean Time (GMT)
            return val.ToUniversalTime().ToString("yyyyMMddThhmmssZ");
        }
    
        private static string ToCFDateOnlyString(DateTime val)
        {
            //format: YYYYMMDD where YYYY = year, MM = month, DD = date, T = start of time character, hh = hours, mm = minutes,
            //ss = seconds, Z = end of tag character. The entire tag uses Greenwich Mean Time (GMT)
            return val.ToUniversalTime().ToString("yyyyMMdd");
        }
    
        private static string ToCFString(string str)
        {
            return str.Replace("r", "=0D").Replace("n", "=0A");
        }
    
        private static string ToOneLineString(string str)
        {
            return str.Replace("r", " ").Replace("n", " ");
        }
    }
