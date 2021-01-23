    public void addtableToSet()
    {
        DataTable tableA = new DataTable("TableA");
        DataTable tableB = new DataTable("TableB");
        DataTable tableC = new DataTable("TableC");
        dataContainer.Tables.Add(tableA);
        dataContainer.Tables.Add(tableB);
        dataContainer.Tables.Add(tableC);
        dataContainer.Tables.Add(new DataTable("TableD"));
    }
    public void RemoveTableFromSet(string tableName)
    {
        dataContainer.Tables.Remove(tableName); 
    }
