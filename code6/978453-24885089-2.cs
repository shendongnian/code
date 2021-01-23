    ComboBox cbm;
    DataGridViewCell currentCell;
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            cbm = (ComboBox)e.Control;
            if (cbm != null)
            {
                cbm.SelectedIndexChanged += new EventHandler(cbm_SelectedIndexChanged);
            }
            currentCell = this.dataGridView1.CurrentCell;
        }
    }
        
    void cbm_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BeginInvoke(new MethodInvoker(EndEdit));
    }
        
        
    void EndEdit()
    {
        if (cbm != null)
        {
            string SelectedItem=cbm.SelectedItem.ToString();
            int i = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[i].Cells["Test"].Value = SelectedItem;
        }
    }
