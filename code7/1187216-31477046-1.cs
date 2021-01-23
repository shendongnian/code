    private void CreateNormDefinitionColumns()
    {
        foreach (var definition in Assessment.Definitions)
        {
            Binding binding = new Binding(String.Format("[{0}].Value", definition.ColumnName));
            binding.Mode = BindingMode.TwoWay;
    
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = definition.ColumnName;
            column.Binding = binding;
            ParameterDataGrid.Columns.Add(column);
        }
    }
