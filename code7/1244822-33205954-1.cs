    propDataTable = new DataTable();
    propDataTable.Columns.Add("A", typeof(Item));
    propDataTable.Columns.Add("B", typeof(Item));
    DataRow row0 = propDataTable.NewRow();
    DataRow row1 = propDataTable.NewRow();
    row0[0] = new Item("A0");
    row0[1] = new Item("B0");
    row1[0] = new Item("A1");
    row1[1] = new Item("B1");
    propDataTable.Rows.Add(row0);
    propDataTable.Rows.Add(row1);
    propCopyDataTable = propDataTable.Copy();
    //now set a different value in propCopyDataTable
    propCopyDataTable.Rows[1][1] = new Item("Changed");
    //find out which cells in column B are different
    //try to show in red text which cell changed
    for (int i = 0; i < propDataTable.Rows.Count; i++) {
         DataRow dr = propDataTable.Rows[i];
         DataRow drc = propCopyDataTable.Rows[i];
         if (!object.Equals(dr["B"], drc["B"])) {
             (dr["B"] as Item).SetChanged();
         }         
    }
