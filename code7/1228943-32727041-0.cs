    dgv.ColumnCount = 14;
    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
    ......
    dgv.Columns[0].Name = "Class";
    dgv.Columns[0].DataPropertyName = "Class";
    ....
    dgv.Columns[13].Name = "CheckedBy";
    dgv.Columns[13].DataPropertyName = "CheckedBy";
