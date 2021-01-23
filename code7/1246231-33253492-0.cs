    private void del_Mult_Click(object sender, EventArgs e)
    {
        List<DataGridViewRow> deleteRows = new List<DataGridViewRow>();
    
        foreach(DataGridViewRow row in EditdataGridView1.Rows)
        {
            if(Convert.ToBoolean(row.Cells[0].Value) == true)
            {
                int id = Convert.ToInt16(row.Cells[1].Value);
                DeleteMult(id);
                deleteRows.Add(row);
            }
        }
    
        foreach(DataGridViewRow row in deleteRows)
        {
            EditdataGridView1.Rows.Remove(row);
        }
    }
