    TimeSpan StartTime = TimeSpan.FromHours(5);
      int Difference = 15;
                int EntriesCount = count;
                Dictionary<TimeSpan, TimeSpan> Entries = new Dictionary<TimeSpan, TimeSpan>();
    
    
     
    
       for (int TableRowId = 0; TableRowId <= count - 1; TableRowId++)
            {
    
               string inTime = "//*[@id='INTIME" + TableRowId + "']";
                string outTime = "//*[@id='OUTTIME" + ableRowId + "']";
      
               test.Type(inTime, StartTime.Add(TimeSpan.FromMinutes(Difference * TableRowId)).ToString("hh\\:mm"));
                test.Type(outTime, StartTime.Add(TimeSpan.FromMinutes(Difference * TableRowId + Difference)).ToString("hh\\:mm"));
          }
