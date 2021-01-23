    List<DateTime> DateList = new List<DateTime>();
    
    DateList.Add(DateTime.Parse("7 / 20 / 2015 2:15:23 PM"));
    DateList.Add(DateTime.Parse(" 7 / 20 / 2015 2:16:06 PM"));
    DateList.Add(DateTime.Parse(" 7 / 26 / 2015 11:39:15 PM"));
    DateList.Add(DateTime.Parse(" 9 / 2 / 2015 10:51:46 PM"));
    DateList.Add(DateTime.Parse(" 9 / 2 / 2015 10:52:33 PM"));
    DateList.Add(DateTime.Parse(" 10 / 26 / 2015 8:42:23 PM"));
    DateList.Add(DateTime.Parse(" 11 / 12 / 2015 2:54:31 PM"));
    DateList.Add(DateTime.Parse(" 11 / 30 / 2015 6:49:10 AM"));
    DateList.Add(DateTime.Parse(" 12 / 2 / 2015 10:18:17 AM"));
    DateList.Add(DateTime.Parse(" 12 / 10 / 2015 8:34:53 AM"));
    DateList.Add(DateTime.Parse(" 12 / 10 / 2015 3:15:33 PM"));
    DateList.Add(DateTime.Parse(" 12 / 15 / 2015 6:43:32 AM"));
    DateList.Add(DateTime.Parse(" 12 / 29 / 2015 2:55:01 AM"));
    DateList.Add(DateTime.Parse(" 1 / 12 / 2016 7:46:45 PM"));
    DateList.Add(DateTime.Parse(" 1 / 13 / 2016 7:31:14 AM"));
    DateList.Add(DateTime.Parse("1 / 13 / 2016 7:32:59 AM"));
    DateList.Add(DateTime.Parse("1 / 14 / 2016 5:28:33 AM"));
    
    Dictionary<int, int> MyHistogram = new Dictionary<int, int>();
    
    foreach(DateTime MyDateTime in DateList)
    {
        int Week = MyDateTime.DayOfYear / 7;
    
        if (MyHistogram.ContainsKey(Week))
            MyHistogram[Week]++;
        else
            MyHistogram.Add(Week, 1);
    }
