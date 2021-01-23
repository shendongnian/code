    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        int limit = (int)numericUpDown1.Value;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            var dbo = (DataRowView)row.DataBoundItem;
            row.Visible = (int)dbo[2] >= limit;
        }
    }
