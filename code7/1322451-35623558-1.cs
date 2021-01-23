        public DateTime StartTime
        {
            get
            {
                if (Year < 1) Year = 1;
                if (Month < 1) Month = 1;
                if (Day < 1) Day = 1;
                if (StartHour < 0) StartHour = 0;
                if (StartMinute < 0) StartMinute = 0;
                return new DateTime(Day, Month, Year, StartHour, StartMinute, 0);
            }
            set
            {
                Day = value.Day;
                Month = value.Month;
                Year = value.Year;
                StartHour = value.Hour;
                StartMinute = value.Minute;
            }
        }
