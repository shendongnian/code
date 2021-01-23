    private void btn_Click(object sender, EventArgs e)
    {
        empIDs.Clear();
        foreach(DataGridViewRow r in dgv.Rows)
        {
            DataGridViewCheckBoxCell c = r.Cells["Select"] as DataGridViewCheckBoxCell;
            if(Convert.ToBoolean(c.Value))
                empIDs.Add(Convert.ToInt32(r.Cells["Employee No"].Value));        
        }
    }    
