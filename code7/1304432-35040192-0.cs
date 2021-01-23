    List<string> playerNameList = new List<string>(); 
    using (OleDbReader r = command.ExecuteReader())
    {
       while(reader.Read())
       {
         playerNameList.Add(reader.GetString(0));
       }
    }
