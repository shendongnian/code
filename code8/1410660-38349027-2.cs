    private void DgDataTable_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "ColorBackground")
        {
            e.Column.CellStyle = (sender as DataGrid).FindResource("ColorPickerCell") as Style;
        }
    }
