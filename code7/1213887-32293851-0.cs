    private void yourDatagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(DateTime))//if a column is typeof DateTime
        {
            (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy-MM-dd";//set your date format 
        }
    }
