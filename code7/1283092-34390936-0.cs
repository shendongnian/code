    foreach (FileInfo flInfo in directory.GetFiles())
    {
        DateTime yesterday = DateTime.Today.AddDays(-1);
        String name = flInfo.Name.Substring(3,4);
        DateTime creationTime = flInfo.CreationTime;
        if (creationTime.Date == yesterday.Date)
           yesterdaysList.Add(name);
    }
