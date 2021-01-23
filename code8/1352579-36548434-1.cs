    private void buttonDiscard_Click(object sender, EventArgs e)
    {
        DataGridViewCell cell = this.dataGridView1.CurrentCell;
        DataGridViewRow row = cell.OwningRow;
        if (row.HasDefaultCellStyle)
        {
            row.DefaultCellStyle = null;
            Debug.Assert(!row.HasDefaultCellStyle);
        }
        if (cell.HasStyle)
        {
            cell.Style = null;
            Debug.WriteLine(!cell.HasStyle);
        }	
    }
