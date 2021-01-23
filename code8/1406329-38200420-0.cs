    var groupedList = list.GroupBy(u => u.state)
                                    .OrderBy(grp => StateToOrder(grp.Key))
                                    .Select(grp => 
                                        new
                                        {
                                            grp.Key,
                                            Data = grp.OrderBy(x => Convert.ToInt32(x.rank)) 
                                        });
    
    foreach(var g in groupedList)
    {
        g.Data; // Key;
        g.Data; // Ordered List for that state
    }
