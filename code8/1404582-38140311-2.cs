      List<DateTime> dtList = new List<DateTime>();
      dtList.Add(new DateTime( 2016, 6,29));
      dtList.Add(new DateTime( 2016,6, 27));
      dtList.Add(new DateTime( 2016,6 ,24));
      dtList.Add(new DateTime( 2016,6,22 ));
      dtList.Add(new DateTime( 2016,6,21 ));
      dtList.Add(new DateTime( 2016,6, 15 ));
      dtList.Add(new DateTime( 2016, 6,13));
      List<DateTime> dtResult = dtList
          .GroupBy(x => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(x, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
          .Select(x => x.OrderByDescending(y => y).First())
          .ToList();
