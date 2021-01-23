     public void Insert()
     {
         //myDb = new OleDbConnection(conn + dbFile);
         myDb.Open();
    
         OleDbCommand cmd = new OleDbCommand("INSERT INTO Employee(Username, Password, email, phone) VALUES ('" + insUn + "','" + insPass + "','" + insNm + "','" + insNmr + "')", myDb);
    
          cmd.ExecuteNonQuery();
    
         myDb.Close();
     }
