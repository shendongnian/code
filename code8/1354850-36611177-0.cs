    public class DateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Overlaps(DateRange otherRange)
        {
            if (StartDate < otherRange.EndDate && StartDate >= otherRange.StartDate)
                return true;
            if (otherRange.StartDate < EndDate && otherRange.StartDate >= StartDate)
                return true;
            if (EndDate > otherRange.StartDate && EndDate <= otherRange.EndDate)
                return true;
            if (otherRange.EndDate < StartDate && otherRange.EndDate >= EndDate)
                return true;
            return false;                
        }
