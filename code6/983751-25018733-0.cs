    private void dgLFKPI_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName.Contains('/') && e.Column is DataGridBoundColumn)
        {
            var col = e.Column as DataGridBoundColumn;
            col.Binding = new Binding(string.Format("[{0}]", e.PropertyName));
        }
    }
