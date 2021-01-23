    public void text()
    {
         List<string> oWords =  new List<string>();
         string sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data source=PathtoYourAccessDB.accdb";
         string sQueryString=  "select YourWordsColumn from YouAccessTable";
        
         using (OleDbConnection oConnection = new OleDbConnection(sConnectionString))
         {
              OleDbCommand oCommand = new OleDbCommand(sQueryString, oConnection);
              oConnection.Open();
              using (OleDbDataReader oReader = oCommand.ExecuteReader())
              {
                   while (oReader.Read())
                         oWords.Add(oReader.GetValue(0).ToString());
              }
         }
         // If you want the words in an array
         string [] words = oWords.ToArray();
    }
