     List<DateDuplicate> RemoveAndMark(List<DateTime> dates)
        {
            var dateValues =  dates.GroupBy(y => new { AddHours = y.Date.Date.AddHours(y.Hour), y.Minute}).Select(x =>
         
             new DateDuplicate {isDuplicate = x.Count() > 1, date = x.Key.AddHours.AddMinutes(x.Key.Minute)}
         );
            return dateValues;
        }
