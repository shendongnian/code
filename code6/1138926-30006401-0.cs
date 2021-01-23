    private void btnUpdate_Click(object sender, EventArgs e)
    {
        List<DataGridViewRow> rowCollection = new List<DataGridViewRow>();
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            // Adds the selected rows in order from most recently selected to first selected.
            rowCollection.Add(dataGridView1.Rows[row.Index]);
            // Adds the selected rows in order from first selected to most recently selected.
            //rowCollection.Insert(0, dataGridView1.Rows[row.Index]);
        }
        DataTable clone = this.DataSet.Tables[0].Clone();
        foreach (DataGridViewRow row in rowCollection)
        {
            object[] values = new object[row.Cells.Count];
            for (int i = 0; i < row.Cells.Count; i++)
            {
                values[i] = row.Cells[i].Value;
            }
            clone.Rows.Add(values);
        }
        this.DataSet.Tables[0].Clear();
        this.DataSet.Tables[0].Merge(clone);
    }
