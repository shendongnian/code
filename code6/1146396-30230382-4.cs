    public class DateRange
    {
        private DateTime? _start;
        private DateTime? _end;
        public DateTime? Start
        { 
            get { return _start; }
            //get rid of any sentinel value
            set { _start = value == DateTime.MinValue ? null : value; } 
        }
        public DateTime? End
        { 
            get { return _end; }
            // get rid of any sentinel value
            set { _end = value == DateTime.MaxValue ? null : value; }
        } 
        //For checking results
        public override string ToString()
        {
            return String.Format("{0}-{1}", Start.HasValue ? Start.Value.ToShortDateString() : "null", End.HasValue ? End.Value.ToShortDateString() : "null");
        }
    }
