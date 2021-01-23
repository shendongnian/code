    List<TimeSpan> times = new List<TimeSpan>();
    
    foreach (DataRow row in dtChats.Rows)
    	times.Add(TimeSpan.Parse(row["TotalTime"].ToString()));
    	
    long averageTicks = Convert.ToInt64(list.Average(ts => ts.Ticks));
    TimeSpan myAverage = new TimeSpan(averageTicks);
