    //Assuming that 
    //IEnumerable<string[]> this.InfoFromDatabase
    var allInformation = this.InfoFromDatabase.Where(i =>
    {
        var thisTime = DateTime.ParseExact(i[5], "yyyy-M-d H:m:s", null);
        return thisTime > minimumDateTime && thisTime < maximumDateTime;
    });
