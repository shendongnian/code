    int colIndex = CheckBoxColumn1.Index; // or dataGridView1.Columns.IndexOf(CheckBoxColumn1.Name) ?
    for ( int r = 0; r < dataGridView1.RowCount; r++ )
    {
        if ( true.Equals( dataGridView1[colIndex, r].Value ) )
        {
            //...
        }
    }
