    abc = Getname();
    string tablename = GetTableName(abc);
    ...
    
    public string GetTableName(string abc)
    {
      if (abc == "AC")
       return DumbTable.AC;
      else if (abc == "AG")
       return DumbTable.DG;
      else
       return "";
    }
