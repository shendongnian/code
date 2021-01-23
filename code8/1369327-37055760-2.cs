    List<IRecord> records = new List<IRecord>();
    
    private void CreateAllObjects(System.Type _type, DataTable table)
    {
      
        foreach (DataRow row in table.Rows)
        {
            int recordID = int.Parse(row["Record_ID"].ToString());
            
            //If the record is of the passed in type and doesn't have an existing object in the collection, create it.
            if ((!records.Where(t => t is _type).Any(s => s.Record_ID == recordID)))
                {
                
                    IRecord record = (IRecord)Activator.CreateInstance(_type);
                    //initialize record
                    records.Add(record);
                }  
          
        }
    }
