    void BtnFilterClick(object sender, EventArgs e)
    {
        // create new DataTable
        DataTable filteredDataTable = new DataTable();
        filteredDataTable.Columns.Add("csv column");
        DataTable dt = ((DataTable)DataGridValue.DataSource);
        foreach (DataGridViewRow row in DataGridValue.Rows)
        {
            // Test if the first column of the current row equals
            // the value in the text box
            if ((String)row.Cells["Northing"].Value == tbxX1.Text)
            {
                // we have a match
                filteredDataTable.Add(row)
            }
        }
        DataGridValue.DataSource = null;
        DataGridValue.DataSource = filteredDataTable;
    }
