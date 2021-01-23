    public int GetMailMergeLastRecord()
     {
           Document doc = Globals.AddIn.ActiveDocument;      
           // for storing current record
           int currentRec = (int)doc.Mailmerge.DataSource.ActiveRecord;
           //getting the last Record
           int lastRecord = 1;
           doc.MailMerge.DataSource.ActiveRecord = (doc.MailMerge.DataSource.ActiveRecord - (int)doc.MailMerge.DataSource.ActiveRecord) + Int32.MaxValue;
           lastRecord =  (int)doc.MailMerge.DataSource.ActiveRecord;
    
           // resetting the current record as above line of codes will change the active record to last record.
           doc.MailMerge.DataSource.ActiveRecord = (doc.MailMerge.DataSource.ActiveRecord - (int)doc.MailMerge.DataSource.ActiveRecord) + currentRec;
           return lastRecord;
    }
