    //create a sort order that starts yesterday
    DateTime orderStartDate = DateTime.Today.AddDays(-1);
    List<int> sortOrder = Enumerable.Range(0,7).Select(days => (int)orderStartDate.AddDays(days).DayOfWeek).ToList();
    
    //sort collection using the index of the sortOrder
    collection.AddRange(list.OrderBy(list  => sortOrder.FindIndex(days => day == list.TargetDay)));
