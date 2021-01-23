    //Get the time part with TimeOfDay
    DateTime dt = new DateTime(2015, 10, 3, 11, 50, 00); //03/10/2015 11:50:00
    var time = dt.TimeOfDay; //11:50:00
    //Or get a TimeSpan directly
    time = new TimeSpan(11, 50, 00); //11:50:00
    //Add the new TimeSpan
    var nextTime = time.Add(new TimeSpan(0, 10, 00)); //12:00:00
