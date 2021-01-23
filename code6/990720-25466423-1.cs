    private void AutoGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
      if (e.PropertyType.IsArray || 
        e.PropertyType.ToString().ToUpperInvariant().Contains("Dictionary".ToUpperInvariant()) ||
        e.PropertyType.ToString().ToUpperInvariant().Contains("List".ToUpperInvariant()))
      {
        MyDataGridComboBoxColumn col = new MyDataGridComboBoxColumn();
        col.ColumnName = e.PropertyName;
        e.Column = col;
        e.Column.Header = e.PropertyName;
      }
    }
