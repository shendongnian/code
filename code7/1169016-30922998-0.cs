    SortedDictionary<DateTime, double> columnInfos = new SortedDictionary<DateTime, double>();
    List<KeyValuePair<DateTime, double>> columnInfosList = columnInfos.ToList();
    foreach (var activity in activities)
    {
        DateTime activityDate = activity.ActivityDateTime;
    
        for (int index = 1; index < columnInfosList.Count(); index++)
        {
             if (columnInfosList[index-1].Key < activityDate && columnInfosList[index+1].Key > activityDate)
             {
                  // do something with columnInfos[index-1] and columnInfos[index+1] then break so you stop searching
             }
        }
    }
