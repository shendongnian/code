    if (chkRx.Checked)`
    {
        DataGridViewComboBoxColumn rxColumn = new DataGridViewComboBoxColumn();
        rxColumn.Name = "RX";
        //rxColumn.DataPropertyName = "BRxs";
        rxColumn.DataSource = datafrequencies;
        rxColumn.ValueMember = "frequencyId";
        rxColumn.DisplayMember = "frequencyName";
        dgResult.Columns.Add(rxColumn);
    }
    dgResult.DataSource = data;`
