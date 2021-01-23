        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType.IsEnum)
            {
                e.Column = new EnumTemplateColumn(e.PropertyType)
                {
                    Header = e.Column.Header,
                };
            }
        }
