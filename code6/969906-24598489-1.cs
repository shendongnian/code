    public override DataGridColumn GetDataGridColumn(string header, bool isReadOnly, string fieldName)
    {
        DatePickerDataGridColumn dgCol = new DatePickerDataGridColumn();
        dgCol.Header = header;
        dgCol.IsReadOnly = isReadOnly;
        Binding b = new Binding(fieldName);
        if (isReadOnly) { b.Mode = BindingMode.OneWay; }
        dgCol.SelectedDateBinding = b;
        return dgCol;
    }
