    var sortedList = new[] { 
        new Column { ColName = "Name", SortOrder = SortOrder.Asc },
        new Column { ColName = "custom_Secret", SortOrder = SortOrder.Asc },
    };
    var col = sortedList[0];
    var sortedData = OrderByCustomer(customers, sortedList[0]);
    for (int i = 1; i < sortedList.Length; i++)
    {
        sortedData = OrderByCustomer(sortedData, sortedList[i]);
    }
    var result = sortedData.ToArray();
