    public DataTable table  { get; set; }
    // Here we create a DataTable 
    table = new DataTable();
    table.Columns.Add("Col1", typeof(int));
    table.Columns.Add("Col2", typeof(string));
    table.Columns.Add("Col3", typeof(string));    
    // Here we add DataRows.
    table.Rows.Add(1, "john", "doe");
    table.Rows.Add(2, "jane", "doe");
   
