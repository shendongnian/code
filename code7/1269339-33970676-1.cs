    DataRow[] userRow = newsdataset.Tables["users"].Select("Id = " + userid);
    if (userRow != null && userRow.Length != 0)
    {
         string connectionName = string.Empty;
         for( int i = 0; i < userRow.Length; i++)
         { 
             connectionName += userRow[i].ToString() + " ";
          }
    } 
    var result = connectionName;
