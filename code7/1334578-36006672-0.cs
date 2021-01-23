    for(int i =0; i< DataGridView.Rows.Count; i++))
    {
        if (Convert.ToInt32( DataGridView.Rows[i].Cells["Column28"].Value) < 2 )
        {
            DataGridView.Rows.RemoveAt(i);
            i--;
        }
        else
        {
            if (Convert.ToInt32(DataGridView.Rows[i].Cells["Column29"].Value) < 6)
            {
                DataGridView.Rows.RemoveAt(i);
                i--; 
            }
        }
    }
