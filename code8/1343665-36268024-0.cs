    public class Period : DatePeriod
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            Period other = (Period)obj;
            return StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate);
        }
        public override int GetHashCode()
        {
            return new {StartDate, EndDate}.GetHashCode();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
