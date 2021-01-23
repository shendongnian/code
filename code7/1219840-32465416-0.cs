     List<DateDuplicate> RemoveAndMark(List<DateTime> dates)
        {
            var dateValues = dates.GroupBy(y => new { y.Date.Date, y.Minute }).Select(x =>
                new DateDuplicate { isDuplicate = x.Count() > 1, date = x.Key.Date.AddMinutes(x.Key.Minute) }
                ).ToList();
            return dateValues;
        }
