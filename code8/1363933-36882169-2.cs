    list = list.Cast<object>().Select( (v, i) => new {Value= v, Index = i});
    
    foreach(var row in list)
    {
        bool IsChecked = (bool)((CheckBox)DataGridDetail.Columns[0].GetCellContent(row.Value)).IsChecked;
        row.Index ...
    }
