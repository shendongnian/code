       using System;
       using System.Globalization;
       using System.Linq;
    
        public static DateTime PersianDateToGregorianDate(string pDate)
        {
            var dateParts = pDate.Split(new[] { '/' }).Select(d => int.Parse(d)).ToArray();
            var hour = 0;
            var min = 0;
            var seconds = 0;
            return new DateTime(dateParts[0], dateParts[1], dateParts[2],
                                hour, min, seconds, new PersianCalendar());
        }
