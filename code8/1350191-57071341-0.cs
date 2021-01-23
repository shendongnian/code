    TSqlObject table;
    
    // Code initializing the variable
    
    // Get the type of retention. This can be either -1 (if Infinite)
    // or one of the value in the TemporalRetentionPeriodUnit enum
    var retentionUnit = table.GetProperty<int>(Table.RetentionUnit);
    
    // Get the retention value. If retention is Infinite this will be -1
    var retentionValue = table.GetProperty<int>(Table.RetentionValue);
    
    // Get a reference to the history table. 
    var historyTable = table.GetReferenced(Table.TemporalSystemVersioningHistoryTable);
