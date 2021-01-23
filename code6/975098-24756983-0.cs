           DataRow[] rowColl = new DataRow[dgTemp.Rows.Count];//dgTemp is the datagridview
            DataTable dtTable = new DataTable();
            foreach (DataGridViewColumn dgvColumn in dgTemp.Columns)
            {
                dtTable.Columns.Add(dgvColumn.Name);
            }
            DataRow newRow;
            int i = 0;
            foreach (DataGridViewRow dRow in dgTemp.Rows)
            {
                newRow = dtTable.NewRow();
                foreach (DataGridViewColumn dgvColumn in dgTemp.Columns)
                {
                    newRow[dgvColumn.Name] = dRow.Cells[dgvColumn.Name].Value;
                }
                rowColl[i] = newRow;
                ++i;
            }
}
