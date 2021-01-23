    var missedDateDictionary = new Dictionary<DateTime, bool>(); // or other value
    var date = new DateTime(2016, 01, 01);
    for (int i = 0 ; i < 32 ; i++)
    {
        var newDate = date.AddDays(i);
        //do something with adding / not adding date
        
        if (notDoneSomething)
            missedDateDictionary.Add(newDate, true)
    }
