    var dgv = new DataGridView();
    
    var dgvTextColumn = new DataGridViewTextBoxColumn();
    dgvTextColumn.Name = "columnName"; // to use for future column references
    dgvTextColumn.DataPropertyName = "columnName"; // I prefer to keep this and .Name property the same
    dgvTextColumn.HeaderText = "columnHeader";
    dgvTextColumn.Width = 50;
    dgvTextColumn.ReadOnly = false;
    dgv.Columns.Add(dgvTextColumn);
