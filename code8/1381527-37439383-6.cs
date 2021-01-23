    private bool ValidateHeaders(DataTable importData, DataTable importDataSourceSchema)
    {
        bool isValid = true;
    
        if (importData.Columns.Count != importDataSourceSchema.Columns.Count)
        {
            isValid = false;
            ValidationLabel.Text = ValidationLabel.Text + "<br />Wrong number of columns";
        }
    
        for (int i = 0; i < importData.Columns.Count; i++)
        {
            if (importData.Columns[i].ColumnName != importDataSourceSchema.Columns[i].ColumnName)
            {
                ValidationLabel.Text = ValidationLabel.Text + "<br />Error finding column " + importData.Columns[i].ColumnName;
                isValid = false;
            }
        }
        return isValid;
    }
