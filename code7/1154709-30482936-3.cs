    Hashtable hTable = new Hashtable();
    
    foreach(Table table in Tables)
    {
       foreach (DataRow row in table.Rows)
       {
          if (hTable.Contains(row["empID"]))
             row.Delete();
          else
             hTable.Add(row["empID"], string.Empty); 
       }
    }
