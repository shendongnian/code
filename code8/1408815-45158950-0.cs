    Script s = new Script();
    s.DoString(luaCode);
    Table tableData = s.Globals[rootTableIndex] as Table;
    for (int i = 1; i < tableData.Length + 1; i++) {
        Table subTable = tableData.Get(i).Table;
        //Do cool stuff here with the data
    }
