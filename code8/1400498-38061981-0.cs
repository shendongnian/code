    private void m_LibraryItemClickedNone(object sender, EventArgs e)
    {
        dataGridView1.CurrentCell = null;    
        foreach (DataGridViewRow dgvr in gvLibrary.Rows)
        {
            if (dgvr.Selected)
               dgvr.Selected = false;
            dgvr.Cells["LSelect"].Value = false;
        }
    }
