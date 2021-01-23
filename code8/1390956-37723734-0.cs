    private void DataGridOnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Company")
        {
            var c = (DataGridTextColumn)e.Column;
            var b = (Binding)c.Binding;
            b.Path = new PropertyPath("Company.Name");
        }
    }
