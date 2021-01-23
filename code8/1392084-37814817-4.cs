        public static DataSet loadData()
        {
            DataTable myDataTable = MakeTableHeaders();
            // Add a new empty data row to our data model.
            DataRow theDataRow = programTable.NewRow();
            
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
