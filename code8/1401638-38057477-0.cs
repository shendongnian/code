    void CopyTableColumnsFromDGV(DataGridView dgv, DataTable dt)
    {
        foreach (DataGridViewColumn dgvCol in dgv.Columns)
        {
            DataColumn dtCol = new DataColumn(dgvCol.Name, dgvCol.ValueType);
            dtCol.Caption = dgvCol.HeaderText;
            dt.Columns.Add(dtCol);
        }
    }
