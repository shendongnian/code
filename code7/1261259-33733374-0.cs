        class Date
        {
            private int _month; // 1-12
            private int _day; // 1-31 depending on month
            private int _year;
            public Date(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }
            public int Year
            {
                get { return _year; }
                set
                {
                    _year = value;
                    //Do you checks and throw exception as needed
                    //throw new ArgumentOutOfRangeException("year", value, "year out of range");
                }
            }
            public int Month
            {
                get { return _month; }
                set
                {
                    if (value > 0 && value <= 12)
                        _month = value;
                    else
                        throw new ArgumentOutOfRangeException("Month", value, "Month must be 1-12");
                }
            }
            public int Day
            {
                get { return _day; }
                set
                {
                    int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                    if (value > 0 && value <= days[_month])
                        _day = value;
                    else if (_month == 2 && value == 29 &&
                        _year % 400 == 0 || (_year % 4 == 0 && _year % 100 != 0))
                        _day = value;
                    else
                        throw new ArgumentOutOfRangeException("Day", value, "Day is out of range");
                }
            }
        }
