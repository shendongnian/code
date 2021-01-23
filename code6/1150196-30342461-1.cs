    foreach (string Tablename in uniqueFields)
    {
        // not required List<string> TblName = Tablename;//here the problem
    
        // doesn't make sense, and is not required TblName = new List<string>();
    
        //Console.WriteLine("children of :" + TblName); // use the line below instead
        Console.WriteLine("children of :" + Tablename);
        foreach (string TableAssociatedValue in fields)
        {
            if (TableAssociatedValue.Contains(Tablename.Trim()))
            {
                Console.WriteLine(TableAssociatedValue);
            }
        }       
    }
