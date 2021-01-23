    //string[] listOfTableNames;
    listOfTableNames = GetTableNames(ds);
    for (int i = 0; i < ds.Tables.Count; i++)
    {
       da.TableMappings.Add("table" + i.ToString(), listOfTableNames[i]);
    }
