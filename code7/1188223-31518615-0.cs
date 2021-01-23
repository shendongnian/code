            // Declare a DataTable
            DataTable dtNames = new DataTable("dtNames");
            // Add column to the DataTable
            dtNames.Columns.Add("Name");
            DataRow drName = null;
            // Loop to add new rows with unique names
            for (int i = 1; i < 10; i++ )
            {
                drName = dtNames.NewRow();
                drName["Name"] = "Name0" + i;
                dtNames.Rows.Add(drName);
            }
