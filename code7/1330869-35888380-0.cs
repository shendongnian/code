    private List<DateTime> ReturnWeek(int getDay)
    {
        List<DateTime> returnList = new List<DateTime>();
        //DateTime now = DateTime.Now;
        DateTime now = DateTime.UtcNow.Date;
        //DateTime now = new DateTime(2015, 11, 09);
        //int dayOfWeek = (int)now.DayOfWeek;
        DateTime startOfWeek6 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay);
        DateTime endOfWeek6 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6);
        DateTime startOfWeek5 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - 7);
        DateTime endOfWeek5 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - 7);
        DateTime startOfWeek4 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - 14);
        DateTime endOfWeek4 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - 14);
        DateTime startOfWeek3 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - 21);
        DateTime endOfWeek3 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - 21);
        DateTime startOfWeek2 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - 28);
        DateTime endOfWeek2 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - 28);
        DateTime startOfWeek1 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay - 35);
        DateTime endOfWeek1 = now.AddDays((-(int)now.DayOfWeek + 1) - getDay + 6 - 35);
        returnList.Add(startOfWeek6); //index 0
        returnList.Add(endOfWeek6); //index 1
        returnList.Add(startOfWeek5); //index 2
        returnList.Add(endOfWeek5); // ...
        returnList.Add(startOfWeek4);
        returnList.Add(endOfWeek4);
        returnList.Add(startOfWeek3);
        returnList.Add(endOfWeek3);
        returnList.Add(startOfWeek2);
        returnList.Add(endOfWeek2);
        returnList.Add(startOfWeek1);
        returnList.Add(endOfWeek1); //index 10
        return returnList;
    }
    
