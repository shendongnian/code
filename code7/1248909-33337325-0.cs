    var match = SignalTimeOut.Where(s => s.symbol == desiredSymbol).SingleOrDefault();
    if (match == null)
    {
        Action3();
    }
    else
    {
        var age = new TimeSpan(DateTime.Now.Ticks - match.time.Ticks);
        if (age.TotalMinutes() > 60)
            Action2();
        else
            Action1();
    }
