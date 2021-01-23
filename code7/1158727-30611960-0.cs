       DateTime starttime = Convert.ToDateTime(date1);
       DateTime endtime = Convert.ToDateTime(date2);
       TimeSpan span = endtime.Subtract(starttime);
       var datetime = new DateTime(span.Ticks).ToString("H:mm");
       string datetimestring = datetime.ToString().Replace(":",".");
       double timeinDouble =  double.Parse(datetimestring, CultureInfo.InvariantCulture);
