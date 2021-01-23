    internal class FreeTime : IEquatable<FreeTime>
    {
        #region Constants
        private const bool FirstDayOfWeekIsMonday = true;
        #endregion
        #region Private Variables
        private static bool TodayIsSunday = (int) DateTime.Today.DayOfWeek == 0;
        #endregion
        #region Public Fields
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        #endregion
        #region Constructor
        public FreeTime()
        {
            Start = End = DateTime.Today;
        }
        public FreeTime(DateTime s, DateTime e)
        {
            Start = s;
            End = e;
        }
        #endregion
        public enum PeriodType
        {
            SingleMonth,
            AllMonths,
            InterveningMonths
        }
        public bool Equals(FreeTime other)
        {
            ////Check whether the compared object is null.  
            //if (Object.ReferenceEquals(other, null)) return false;
            //Check wether the products' properties are equal.  
            return Start.Equals(other.Start) && End.Equals(other.End);
        }
        public override int GetHashCode()
        {
            //Get hash code for the start field if it is not null.  
            int hashStart = Start.GetHashCode();
            //Get hash code for the end field.  
            int hashEnd = End.GetHashCode();
            //Calculate the hash code .  
            return hashStart ^ hashEnd;
        }
    }
