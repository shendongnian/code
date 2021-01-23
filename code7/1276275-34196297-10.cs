       DataTable tempDataTable = new DataTable();
       DataColumn c = new DataColumn();
       c.ColumnName = "Col1";
       tempDataTable.Columns.Add(c);
    
       c = new DataColumn();
       c.ColumnName = "Col2";
       tempDataTable.Columns.Add(c);
    
       DataRow row1 = tempDataTable.NewRow();
       row1["Col1"] = "Blue";
       row1["Col2"] = "12";;
       tempDataTable.Rows.Add(row1);
    
       DataRow row2 = tempDataTable.NewRow();
       row2["Col1"] = "Red";
       row2["Col2"] = "18";
       tempDataTable.Rows.Add(row2);
    
       DataRow row3 = tempDataTable.NewRow();
       row3["Col1"] = "Yellow";
       row3["Col2"] = "27";
       tempDataTable.Rows.Add(row3);
       this.DataTable = tempDataTable;
