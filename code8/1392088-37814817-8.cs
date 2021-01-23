    //Be sure to include this heading:
    using Infragistics.Win.UltraWinGrid;
    public class ClassName{
        // 1. Make the Headers by adding and defining columns.
        private static DataTable MakeTableHeaders()
        {
            DataTable myDataTable = new DataTable("My Table");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            // Properties:
            // column.DataType   =  set data type (System.Int32, System.String, etc...)
            // column.ColumnName =  set column key (it MUST be unique) (String)
            // column.Caption    =  set the string to be visible for column header. (String)
            // column.ReadOnly   =  set whether the column is editable or not. (Boolean)
            // column.Unique     =  set whether or not values in the column must be unique.
            //                      Unique values = each cell must be different each other.
            //                      (Boolean)
            //// Program ID
            //// Caption "ID"
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID";
            column.Caption = "ID";
            column.ReadOnly = true;
            column.Unique = true;
            // Adds the column to the programTable.
            myDataTable.Columns.Add(column);
            //// Program Name
            //// Caption "Program"
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Program";
            column.Caption = "Program";
            column.ReadOnly = true;
            column.Unique = false;
            // Adds the column to the programTable.
            myDataTable.Columns.Add(column);
            // Add the rest of the necessary columns.
            // ....
            
            // When completed, return the table.
            return myDataTable;
        }
        // 2. Next, add data.
        public static DataSet loadData()
        {
            DataTable myDataTable = MakeTableHeaders();
            // Add a new empty data row to our data model.
            DataRow theDataRow = myDataTable.NewRow();
            
            // Add data
            theDataRow[0] = 0;
            theDataRow[1] = "Program Name";
            // Add the DataRow to the table.
            myDataTable.Rows.Add(theDataRow);
            // Don't forget to accept changes,
            // or the data may not be retained.
            myDataTable.AcceptChanges();
            // Create a new DataSet.
            gridDataSet = new DataSet();
            
            // Add the table to DataSet.
            gridDataSet.Tables.Add(myDataTable);
            // Return the DataSet.
            return gridDataSet;
        }
        
        // 3. Finally, bind data.
        // Do it in the construct of your class
        public ClassName()
        {
            // Use the UltraGrid name you assigned to
            // your UltraGrid.
            ugMyUltraGrid.DataSource = OtherClass.loadData();
        }
    }
