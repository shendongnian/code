    private void myGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (!myGridView.Columns.Contains("Remove"))
        {
            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn();
            removeColumn.Name = "Remove";
            removeColumn.HeaderText = "Remove";
            removeColumn.DataPropertyName = "Remove";
            removeColumn.UseColumnTextForButtonValue = true;
            totalsDataGridView.Columns.Add(removeColumn);
        }
    }
