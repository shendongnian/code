    DateTime yesterdayTime = DateTime.Now.AddDays(-1).Date.AddHours(19);
    DateTime TodayTime = DateTime.Now.Date.AddHours(7);
    List<FileInfo> FilesBetween7To7 = Directory.GetFiles("your path here")
                                               .Select(x => new FileInfo(x))
                                               .Where(y => y.CreationTime > yesterdayTime && 
                                               y.CreationTime < TodayTime)
                                               .ToList();
