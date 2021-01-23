    private static void ExecuteSQL()
    {
        string conn = "User ID=SYSDBA;Password=masterkey;Database=XX.18.137.XXX:C:/ER.TDB;DataSource==XX.18.137.XXX;Charset=NONE;";
        FbConnection myConnection = new FbConnection(conn);
         FbDataReader myReader = null;
         string sql = "SELECT * FROM RDB$RELATIONS";
        FbCommand myCommand = new FbCommand(sql, myConnection);
        try
        {
            myConnection.Open();
            myCommand.CommandTimeout = 0;
            myReader = myCommand.ExecuteReader();
            // 1. print all field names
            for (int i = 0; i < myReader.FieldCount; i++)
            {
              Log.WriteLog(myReader.GetName(i));
            }
            // 2. print each record
            while (myReader.Read())
            {
              // 3. for each record, print every field value
              for (int i = 0; i < myReader.FieldCount; i++)
	          {
                Log.WriteLog(myReader[i].ToString());
              }
            }
            myConnection.Close();
        }
        catch (Exception e)
        {
            Log.WriteLog(e.ToString());
        } 
    }
