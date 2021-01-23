    public override void CreateNewOutputRows()
    {
       while (reader.Read())
       {
          Output0Buffer.AddRow();
          Output0Buffer.Name = reader.GetString(0);
       }
    }
