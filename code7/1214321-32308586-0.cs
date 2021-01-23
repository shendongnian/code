    // Iterate through the SelectedCells collection and sum up the values. 
    for (counter = 0;
        counter < (DataGridView1.SelectedCells.Count); counter++)
    {
        if (DataGridView1.SelectedCells[counter].FormattedValueType ==
            Type.GetType("System.String"))
        {
            string value = null;
            // If the cell contains a value that has not been commited, 
            // use the modified value. 
            if (DataGridView1.IsCurrentCellDirty == true)
            {
                value = DataGridView1.SelectedCells[counter]
                    .EditedFormattedValue.ToString();
            }
            else
            {
                value = DataGridView1.SelectedCells[counter]
                    .FormattedValue.ToString();
            }
            if (value != null)
            {
                // Ignore cells in the Description column. 
                if (DataGridView1.SelectedCells[counter].ColumnIndex !=
                    DataGridView1.Columns["Description"].Index)
                {
                    if (value.Length != 0)
                    {
                        SelectedCellTotal += int.Parse(value);
                    }
                }
            }
        }
