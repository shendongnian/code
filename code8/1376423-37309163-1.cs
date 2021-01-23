    private void Details_RowChanged(object sender, DataRowChangeEventArgs e)
    {
        int change = 0;
        DataSet ds = this.masterBindingSource.DataSource as DataSet;
        if (e.Action == DataRowAction.Add)
        {
            DataRow parent = null;
            foreach (DataRow dr in ds.Tables["Customers"].Rows)
            {
                if (dr["CustomerID"].Equals(e.Row["CustomerID"]))
                {
                    parent = dr;
                    break;
                }
            }
            e.Row.SetParentRow(parent);
        }
        else if (e.Action == DataRowAction.Delete)
        {
            change = -1;
        }
        DataRow row = e.Row.GetParentRow(ds.Relations[0]);
        int index = ds.Tables["Customers"].Rows.IndexOf(row);
        this.masterDataGridView.Rows[index].Cells["CustomColumn"].Value = row.GetChildRows(ds.Relations[0]).Length + change;
    }
