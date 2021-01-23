    private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.KeyCode == Keys.Tab)
       {
           DataGridView1.Enabled = false;
           DataGridView1.GetNextControl(DataGridView1, true).Focus();
           DataGridView1.Enabled = true;
           e.Handled = true;
       }
    }
