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
            ugMyUltraGrid.DataSource = loadData();
        }
        ugMyUltraGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs)
        {
            // This is used to place columns in specific place.
            int headerPosition = 0;
            
            // Set cell editability
            // Activation.ActivateOnly = The context in the cell can be selected, but cannot be edited.
            // Activation.AllowEdit = Allows the cell to be edited.
            // Activation.Disabled = Disables the cell.
            // Activation.NoEdit = Only allows the cell to be activated.
            col.CellActivation = Activation.ActivateOnly;
            
            // Hide all columns
            col.Hidden = true;
           
            // Program ID
            column = "ID";
            ugColumn = e.Layout.Bands[parent].Columns[column];
            e.Layout.Bands[parent].Columns[column].Header.Caption = "ID";
            e.Layout.Bands[parent].Columns[column].Header.VisiblePosition = headerPosition++;
            e.Layout.Bands[parent].Columns[column].Width = 50;
            // To size it to a fixed column width, use this instead:
            // e.Layout.Bands[parent].Columns[column].MinWidth = e.Layout.Bands[parent].Columns[column].MaxWidth = 50;
            // Program Name
            column = "Program";
            e.Layout.Bands[parent].Columns[column].Header.Caption = "Project";
            e.Layout.Bands[parent].Columns[column].Header.VisiblePosition = headerPosition++;
            e.Layout.Bands[parent].Columns[column].Width = 150;
            // To size it to a fixed column width, use this instead:
            // e.Layout.Bands[parent].Columns[column].MinWidth = e.Layout.Bands[parent].Columns[column].MaxWidth = 150;
        }
    }
