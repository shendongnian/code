    int persianYear = 1394;
    int persianMonth = 8;
    int persianDay = 10;
    var persianCalendar = new System.Globalization.PersianCalendar();
    DateTime gregDateTime = persianCalendar.ToDateTime(persianYear, persianMonth, persianDay, 0, 0, 0, 0);
    Debug.WriteLine(
       string.Format(
          "{0}/{1}/{2} in persian is {3}/{4}/{5} in gregorian",
          persianYear,
          persianMonth,
          persianDay,
          gregDateTime.Year,
          gregDateTime.Month,
          gregDateTime.Day
       ));
