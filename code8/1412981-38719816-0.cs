    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGridComboBoxColumn col = e.Column as DataGridComboBoxColumn;
        if (col != null)
        {
            col.ItemsSource = EnumToIEnumerable.GetIEnumerable(e.PropertyType);
            col.DisplayMemberPath = "Value";
            col.SelectedValuePath = "Key";
            col.SelectedValueBinding = new Binding(e.PropertyName);
            col.SelectedItemBinding = null;
        }
    }
