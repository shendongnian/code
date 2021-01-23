    var statusColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Status"];
    statusColumn.DataPropertyName = "Status";
    statusColumn.Items.Add("New");
    statusColumn.Items.Add("Hold");
    statusColumn.Items.Add("Remove");
    // ...
