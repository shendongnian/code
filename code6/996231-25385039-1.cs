    var now = DateTime.Now;
    if (now.DayOfWeek == DayOfWeek.Monday)
    {
        if (now.Hour >= 9 && now.Hour <= 12)
        {
             LoadOhsPage();
        }
        else if (now.Hour >= 12 && now.Hour <= 16)
        {
            LoadSomeOtherPage();
        }
        // ...and so on...
    }
    else if (now.DayOfWeek == DayOfWeek.Tuesday)
    {
         // ...similar to above...
    }
    // ...and so on...
