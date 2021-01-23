    DataTable GeneratedTable1;
    DataTable GeneratedTable2;
    Dictionary<string, DataTable> DataTableDictionary = new Dictionary<string, DataTable>();
    // Adding the tables to the Dictionary
    DataTableDictionary.Add("MyUniqueName1", GeneratedTable1);
    DataTableDictionary.Add("MyUniqueName2", GeneratedTable2);
    // Lookup a DataTable     
    DataTable MyLookedUpDataTable = DataTableDictionary["MyUniqueName1"];
