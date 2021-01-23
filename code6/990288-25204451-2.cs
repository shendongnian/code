    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Tab &&
            dataGridView1.EditingControl != null &&
            msg.HWnd == dataGridView1.EditingControl.Handle  &&
            dataGridView1.SelectedCells
                .Cast<DataGridViewCell>()
                .Any(x => x.ColumnIndex == 6))
        {
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
