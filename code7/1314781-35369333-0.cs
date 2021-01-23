            string daterange = "2016-02-15 17:30:00,2016-02-15 18:00:00;2016-02-16 17:30:00,2016-02-16 18:00:00";
            var result = daterange.Split(';').Select(delegate(string strStartEndDates)
            {
                string[] arrStartEndDates = strStartEndDates.Split(',');
                DateTime dtStart = DateTime.Parse(arrStartEndDates[0]);
                DateTime dtEnd = DateTime.Parse(arrStartEndDates[1]);
                /*
                    TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                    DateTime timeZoneStartDate = TimeZoneInfo.ConvertTime(dtStart, TimeZoneInfo.Local, tst);
                    DateTime timeZoneEndDate = TimeZoneInfo.ConvertTime(dtEnd, TimeZoneInfo.Local, tst);
                */
                return new { Start = dtStart.ToUniversalTime(), End = dtEnd.ToUniversalTime() };
            }).ToList<dynamic>();
            XmlConfigurator.Configure();
