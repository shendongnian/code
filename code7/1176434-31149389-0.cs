    swriter.WriteLine(DateTime.Now.ToString());
    // writes 2015-06-30 23:54:53, but it might look different for you, because it depends on regional settings
    swriter.WriteLine(DateTime.Now.ToLongTimeString());
    // 23:54:53
    swriter.WriteLine(DateTime.Now.ToLongDateString());
    // 30 czerwca 2015 - again dependent on your regional settings
    swriter.WriteLine(DateTime.Now.ToShortTimeString());
    // 23:54
    swriter.WriteLine(DateTime.Now.ToShortDateString());
    // 2015-06-30
