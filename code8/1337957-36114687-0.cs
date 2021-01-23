    private void Grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column.Header.ToString() == "NumberOfBytes")
        {                
             e.Column.IsReadOnly = true; // Makes the column as read only
        }
    } 
