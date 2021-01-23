    string[] tables = new[] { "Class1", "Class2" };
    for(int i = 0; i < tables.Length; i++) {
        Type tableType = Type.GetType(tables[i]);
        database.CreateTable(tableType);
    }
