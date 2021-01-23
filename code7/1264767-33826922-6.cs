    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        // use CompareValidators for the two TextBoxes for rows and columns
		// with it's Operator property set to DataTypeCheck and Type="Integer"
		int rows = int.Parse(txtNoOfRowsRC.Text);
		int columns = int.Parse(txtNoOfColRC.Text);
        grdBinDefinitionDisplay.DataSource = GetDataSource(rows, columns);
        grdBinDefinitionDisplay.DataBind();
    }
    protected DataTable GetDataSource(int rows, int columns)
    {
        DataTable table = new DataTable();
        for (int c = 1; c <= columns; c++)
            table.Columns.Add("Column " + c.ToString());
        for (int r = 1; r <= rows; r++)
        {
            DataRow row = table.Rows.Add();
            foreach (DataColumn col in table.Columns)
            {
                string value = string.Format("{0}{1}{2}", IntToLetters(r), r, col.Ordinal + 1);
                row.SetField(col, value);
            }
        }
		return table;
    }
 
