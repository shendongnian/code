    DateTime yesterdayTime = DateTime.Now.AddDays(-1).Date.AddHours(19);
    DateTime TodayTime = DateTime.Now.Date.AddHours(7);
    List<string> fileList = Directory.GetFiles(csvpath, "*.csv").ToList();
    List<string> FilesInTheRange = new List<string>();
    DateTime fileTime;
    foreach (string file in fileList)
    {
        if (DateTime.TryParseExact(file.Replace(".csv",String.Empty), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fileTime))
        {
            if (fileTime >= yesterdayTime && fileTime <= TodayTime)
                FilesInTheRange.Add(file);
        }
    }
