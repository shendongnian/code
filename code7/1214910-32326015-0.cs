    // Choose either setting 1. or 2. for mExpiryDate.
    // Here setting 1. is active:
    
    // 		1. Simulate expiry date already set on August 17th.
    DateTime mExpiryDate = new DateTime(2015, 9, 17);
    
    //		2. Expiry date not set.
    //DateTime mExpiryDate = DateTime.Today.AddMonths(1);
    
    TimeSpan ts = mExpiryDate.Subtract(DateTime.Today);
    
    // Difference in days.
    int c = ts.Days;
    
    string result = Convert.ToString(c);
