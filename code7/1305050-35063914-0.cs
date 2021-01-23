    private void StartListGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "BirthDate" && e.Column is DataGridTextColumn)
            {
                var textColumn = e.Column as DataGridTextColumn;
                textColumn.Binding = new Binding(e.PropertyName)
                {
                    Converter = new MyValueConverter();
                };
            }
        }
