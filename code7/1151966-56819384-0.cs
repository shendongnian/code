    //First, Get your date in long type because we must use long in the next step.
    //Or if you have your time in string type just use
    //long yourDateTicks = Convert.ToDateTime(yourStringDate).Ticks;
    
    long yourDateTicks = DateTime.Now.Ticks;
    
    //split your DateTime into Day, Month, Year.
    
    int day = new DateTime(yourDateTicks).Day;
    int month = new DateTime(yourDateTicks).Month;
    int year = new DateTime(yourDateTicks).Year;
    
    //Did you see the type of them above? Of course, It's Integer.
    //So you can convert your year into B.C. by simply -543
    
    int bcYear = year - 543;
    
    //Finally, put your items into the blog again and format your desire.
    
    DateTime bcDate = new DateTime(bcYear, month, day);
    String bcDateFormat = bcDate.ToString("yyyy-MM-dd");
