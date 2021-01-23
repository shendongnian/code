    private Dictionary<int, string> _comboBoxValues = new Dictionary<int, string>();
    private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
    {
        if (e.Column.FieldName != "test")
            return;
        int id = (int)gridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, "id");
        if (e.IsSetData)
            _comboBoxValues[id] = (string)e.Value;
        else if (e.IsGetData && _comboBoxValues.ContainsKey(id))
            e.Value = _comboBoxValues[id];
    }
