    List<DataTable> Tables = new List<DataTable>();
  
    //Have some loop to search each item
    IEnumerable<DataRow> query = from MyRows in Olddt.AsEnumerable()
                                 where MyRows.Field<int>("ID") == ItemToSearch || 
                                 MyRows.Field<string>("Value1").Contains(ItemToSearch ) || 
                                 MyRows.Field<string>("Value2").Contains(ItemToSearch )
                                 select MyRows;
    DataTable dtNew = query.CopyToDataTable();
    Tables.Add(ss); // Add New Datatable to Collection of DataTables.
