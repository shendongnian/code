        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(MyTypes))
            {
                DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                templateColumn.Header = e.Column.Header;
                templateColumn.CellTemplate = (DataTemplate)dGrid.Resources["MyTypesCellTemplate"];
                templateColumn.CellEditingTemplate = (DataTemplate)dGrid.Resources["MyTypesCellEditingTemplate"];
                e.Column = templateColumn;
            }
        }
