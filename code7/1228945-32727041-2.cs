    dgv.ColumnCount = 14;
    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
    ... after this add you have 15 columns
    dgv.Columns.Add(checkColumn);
    ...... start indexing at index 0
    dgv.Columns[0].Name = "Class";
    dgv.Columns[0].DataPropertyName = "Class";
    .... decrease the indexing of the other columns by 1
    dgv.Columns[13].Name = "CheckedBy";
    dgv.Columns[13].DataPropertyName = "CheckedBy";
