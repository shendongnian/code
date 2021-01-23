    private void buttonChange_Click(object sender, EventArgs e)
    {
        DataGridViewCell cell = this.dataGridView1.CurrentCell;
        DataGridViewRow row = cell.OwningRow;
        if (!row.HasDefaultCellStyle)
        {
            row.DefaultCellStyle.BackColor = Color.AliceBlue;
        }
        if (!cell.HasStyle)
        {
            cell.Style.ForeColor = Color.Red;
        }
    }
