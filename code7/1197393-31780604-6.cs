        public string PersianDate
        {
            get
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime thisDate = convert your Timestamp to DateTime here ...;
                return string.Format("{0}, {1}/{2}/{3} {4}:{5}:{6}",
                              pc.GetDayOfWeek(thisDate),
                              pc.GetMonth(thisDate),
                              pc.GetDayOfMonth(thisDate),
                              pc.GetYear(thisDate),
                              pc.GetHour(thisDate),
                              pc.GetMinute(thisDate),
                              pc.GetSecond(thisDate));
            }
        }
