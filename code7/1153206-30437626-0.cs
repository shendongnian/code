        using(OleDbConnection oledb = new OleDbConnection(<Your Connection String>))
        {
           oledb.Open();
           using (OleDbCommand oleComm = new OleDbCommand(<sqlString>,oledb)) //the sql passed in as a parameter as your method suggests
           {
               oleComm .CommandType = CommandType.Text; 
               oleComm.ExecuteNonQuery(); 
    
           }
        
        }
