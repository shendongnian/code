    private void DataGrid_AutoGeneratingColumnHandler(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Connected")
            e.Cancel = true;
    }
