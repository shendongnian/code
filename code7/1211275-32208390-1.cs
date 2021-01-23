    private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
    if (e.PropertyName == "ExtensionData")
       {
           e.Column = null;
       }
    }
