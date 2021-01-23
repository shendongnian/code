    public class Week
    {
        public WeekDays Days
        { get; set; }
        public bool Monday
        {
            get { return (Days & WeekDays.Monday) != 0; }
            set { SetDaysFlag(WeekDays.Monday, value); }
        }
        public bool Tuesday
        {
            get { return (Days & WeekDays.Tuesday) != 0; }
            set { SetDaysFlag(WeekDays.Tuesday, value); }
        }
        
        public bool Wednesday
        {
            get { return (Days & WeekDays.Wednesday) != 0; }
            set { SetDaysFlag(WeekDays.Wednesday, value); }
        }
        
        public bool Thursday
        {
            get { return (Days & WeekDays.Thursday) != 0; }
            set { SetDaysFlag(WeekDays.Thursday, value); }
        }
        
        public bool Friday
        {
            get { return (Days & WeekDays.Friday) != 0; }
            set { SetDaysFlag(WeekDays.Friday, value); }
        }
        
        public bool Saturday
        {
            get { return (Days & WeekDays.Saturday) != 0; }
            set { SetDaysFlag(WeekDays.Saturday, value); }
        }
        
        public bool Sunday
        {
            get { return (Days & WeekDays.Sunday) != 0; }
            set { SetDaysFlag(WeekDays.Sunday, value); }
        }
        /// <summary>
        /// Set or unset the flag on the <c>Days</c> property.
        /// </summary>
        /// <param name="flag">The flag to set or unset.</param>
        /// <param name="state">True when the flag should be set, or false when it should be removed.</param>
        private void SetDaysFlag (WeekDays flag, bool state)
        {
            if (state)
                Days |= flag;
            else
                Days &= ~flag;
        }
    }
