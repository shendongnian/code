    string start = "2016-01-07 09:00:00.000";
    string end = "2016-01-07 17:00:00.000";
    DateTime firstDay = Convert.ToDateTime(start);
    DateTime lastDay = Convert.ToDateTime(end);
     
     if (firstDay > lastDay)
     {
    	 
     }
     else
     {
    	TimeSpan span = lastDay - firstDay;
    	int businessDays = span.Days + 1;
    	int fullWeekCount = businessDays / 7;
    	
    	if (businessDays > fullWeekCount * 7)
                {
                    int firstDayOfWeek = (int)firstDay.DayOfWeek;
                    int lastDayOfWeek = (int)lastDay.DayOfWeek;
                    if (lastDayOfWeek < firstDayOfWeek)
                        lastDayOfWeek += 7;
                    if (firstDayOfWeek <= 6)
                    {
                        if (lastDayOfWeek >= 7)
                            businessDays -= 2;
                        else if (lastDayOfWeek >= 6)
                            businessDays -= 1;
                    }
                    else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)
                        businessDays -= 1;
                }
    			
    	businessDays -= fullWeekCount + fullWeekCount;
     }
     
     double hours = 8 * businessDays;
