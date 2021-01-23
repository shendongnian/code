    public void CopyDataGridViews(DataGridView SourceDGV, DataGridView DestinationDGV)
    {
        // Clear Destination DataGridView
        DestinationDGV.Columns.Clear();
        DestinationDGV.Rows.Clear();
        // Create Destination Columns
        for (int j = 0; j < SourceDGV.Columns.Count; j++)
        {
            DestinationDGV.Columns.Add(SourceDGV.Columns[j].Clone() as DataGridViewColumn);
        }
        // Create Destination Rows
        for (int i = 0; i < SourceDGV.Rows.Count - 1; i++)
        {
            DestinationDGV.Rows.Add(SourceDGV.Rows[i].Clone() as DataGridViewRow);
        }
        // Copy Data to Destination
        for (int column = 0; column < SourceDGV.Columns.Count; column++)
        {
            for (int row = 0; row < SourceDGV.Rows.Count; row++)
            {
                DestinationDGV.Rows[row].Cells[column].Value = SourceDGV.Rows[row].Cells[column].Value;
            }
        }
    }
