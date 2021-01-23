     public static bool ChangeEventStatus(Connector cn, EventData eventData)
     {
            int updatedRows = 0;
      
             using (OleDbConnection conn = new OleDbConnection(someConnectionString));
            {
                 conn.Open();
                 using (OleDbCommand cmd = cn.CreateCommand())
                 {
                     cmd.CommandText = "Update EventList Set IsProcessed = ? Where EventId = ?";
    
                     cmd.Parameters.Add("@IsProcessed", OleDbType.Boolean).Value = true;
                     cmd.Parameters.Add("@EventId", OleDbType.BigInt).Value = eventData.EventId;
    
    
                     updatedRows = cmd.ExecuteNonQuery();
    
            }
    
            return (updatedRows == 1);
        }
    }
