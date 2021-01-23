        protected DateTime? getDateTimeFromParts(string day, string month, string year)
        {
            DateTime now = DateTime.Now;
            int iyear;
            if (string.IsNullOrWhiteSpace(year))
            {
                iyear = now.Year;
            }
            else
            {
                iyear = int.Parse(year);
                if (iyear >= 0 && iyear < 100) { iyear += 2000; }
            }
            int imonth;
            if (string.IsNullOrWhiteSpace(month))
            {
                imonth = now.Month;
            }
            else
            {
                imonth = int.Parse(month);
            }
            int iday;
            if (string.IsNullOrWhiteSpace(day))
            {
                iday = now.Day;
            }
            else
            {
                iday = int.Parse(day);
            }
            if (iyear <= DateTime.MaxValue.Year && iyear >= DateTime.MinValue.Year)
            {
                if (imonth >= 1 && imonth <= 12)
                {
                    if (DateTime.DaysInMonth(iyear, imonth) >= iday && iday >= 1)
                        return new DateTime(iyear, imonth, iday);
                }
            }
            return null;
        }
        protected DateTime? getDateTime(string dateStr)
        {
            Regex r = new Regex(@"^(\d\d)(\d\d)((\d\d)?\d\d)$");
            Match m = r.Match(dateStr);
            if (m.Success)
            {
                return getDateTimeFromParts(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
            }
            r = new Regex(@"^(\d?\d|\s\d|\s\s)[-](\d?\d|\s\s)[-]((\d\d)?\d\d|\s\s\s\s)$");
            m = r.Match(dateStr);
            if (m.Success)
            {
                return getDateTimeFromParts(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value);
            }
            return null;
        }
