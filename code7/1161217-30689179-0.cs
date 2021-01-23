    string formattedDate = "";
    var dateTime = DateTime.MinValue;
    if (DateTime.TryParse("06/01/2015", out dateTime))
    {
      formattedDate = dateTime.ToLongDateString(); // switch to "ToLongDateString"
    }
    //short date format = 1/6/2015
    //long date format = 2015年06月01日
