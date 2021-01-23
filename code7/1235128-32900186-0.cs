    System.DateTime date1 = new System.DateTime(1996, 6, 3, 22, 15, 0);
    System.DateTime date2 = new System.DateTime(1996, 12, 6, 13, 2, 0);
    
    // diff1 gets 185 days, 14 hours, and 47 minutes.
    System.TimeSpan diff1 = date2.Subtract(date1);
