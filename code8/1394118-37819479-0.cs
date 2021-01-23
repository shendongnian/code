    void CreateColumns(DataTable dt, DataGridView dgv, string buttons)
    {
        dgv.Columns.Clear();
        for (int i = 0; i < dt.Columns.Count; i++ )
        {
            DataColumn dc = dt.Columns[i];
            if (buttons.Contains(" " + dc.ColumnName + " "))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = dc.Caption;
                buttonColumn.Name = dc.ColumnName;
                buttonColumn.ValueType = dc.DataType;
                buttonColumn.DataPropertyName = dc.ColumnName;
                dgv.Columns.Add(buttonColumn);
            }
            else 
            {   // normal columns
                int c = dgv.Columns.Add(dc.ColumnName, dc.Caption);
                dgv.Columns[c].ValueType = dc.DataType;
                dgv.Columns[c].DataPropertyName = dc.ColumnName;
            }
        }
    }
