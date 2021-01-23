    public class Week
    {
        public WeekDays Days
        { get; set; }
        
        public bool Monday
        {
            get { return Days.HasFlag(WeekDays.Monday); }
            set
            {
                if (value)
                    Days |= WeekDays.Monday;
                else
                    Days &= ~WeekDays.Monday;
            }
        }
        public bool Tuesday
        {
            get { return Days.HasFlag(WeekDays.Tuesday); }
            set
            {
                if (value)
                    Days |= WeekDays.Tuesday;
                else
                    Days &= ~WeekDays.Tuesday;
            }
        }
        
        public bool Wednesday
        {
            get { return Days.HasFlag(WeekDays.Wednesday); }
            set
            {
                if (value)
                    Days |= WeekDays.Wednesday;
                else
                    Days &= ~WeekDays.Wednesday;
            }
        }
        
        public bool Thursday
        {
            get { return Days.HasFlag(WeekDays.Thursday); }
            set
            {
                if (value)
                    Days |= WeekDays.Thursday;
                else
                    Days &= ~WeekDays.Thursday;
            }
        }
        
        public bool Friday
        {
            get { return Days.HasFlag(WeekDays.Friday); }
            set
            {
                if (value)
                    Days |= WeekDays.Friday;
                else
                    Days &= ~WeekDays.Friday;
            }
        }
        
        public bool Saturday
        {
            get { return Days.HasFlag(WeekDays.Saturday); }
            set
            {
                if (value)
                    Days |= WeekDays.Saturday;
                else
                    Days &= ~WeekDays.Saturday;
            }
        }
        
        public bool Sunday
        {
            get { return Days.HasFlag(WeekDays.Sunday); }
            set
            {
                if (value)
                    Days |= WeekDays.Sunday;
                else
                    Days &= ~WeekDays.Sunday;
            }
        }
    }
