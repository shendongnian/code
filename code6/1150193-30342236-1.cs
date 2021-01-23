    foreach (string Tablename in uniqueFields)
    {
       List<string> TblName = new List<string>()
       // <Start Changes>
       TblName.Add(Tablename);
       // <End Changes>
       Console.WriteLine("children of :" + TblName);
       foreach (string TableAssociatedValue in fields)
       {
           if (TableAssociatedValue.Contains(Tablename.Trim()))
           {
              Console.WriteLine(TableAssociatedValue);
           }
       }       
    }
