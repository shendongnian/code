    culturetable.DefaultView.Sort = "date ASC";
    
    Console.WriteLine("==== en-AU ====");
    DateTimeFormatInfo au = new CultureInfo("en-AU", false).DateTimeFormat;     
    foreach(DataRowView row in culturetable.DefaultView){
    	Console.WriteLine(((DateTime)row[0]).ToString(au.ShortDatePattern));
    }
    Console.WriteLine("==== en-US ====");
    DateTimeFormatInfo us = new CultureInfo("en-US", false).DateTimeFormat;     
    foreach(DataRowView row in culturetable.DefaultView){
    	Console.WriteLine(((DateTime)row[0]).ToString(us.ShortDatePattern));
    }
