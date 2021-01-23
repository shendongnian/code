    private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if ((bool)dg.Rows[e.RowIndex].Cells[CheckBoxColumnIndex].Value)
        {
            var rows = (from DataGridViewRow row in Clients.Rows 
                        where row.Index != e.RowIndex
                        select row).ToArray(); 
    
            foreach(DataGridViewRow row in rows)
            {
                 row.Cells[CheckBoxColumnIndex].Value = false;
            }
        }
     }
