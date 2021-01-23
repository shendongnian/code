    List<TickRecords> updates = new List<TickRecords>(); 
    List<TickRecords> inserts = new List<TickRecords>();  
    
    foreach ( var tickRecord in tickRecords ) 
    { 	
        if ( tickRecord.Id == 0 )
        { 		
            updates.Add(tickRecord);
        }
        else
        { 		
            inserts.Add(tickRecords);
         } 
    }
    
    
    
    using ( var db = new SQLiteConnection( new SQLitePlatformWinRT(), DbPath ) ) 
    {
         db.InsertAll(inserts);
         db.UpdateAll(updates);
    }
