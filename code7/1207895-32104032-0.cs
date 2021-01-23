    void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // 2 - Salt, 3 - SecurePassword
        if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
        {
            if (e.Value != null)
            {
                byte[] array = (byte[])e.Value;
                e.Value = BitConverter.ToString(array);
                e.FormattingApplied = true;
            }
            else
                e.FormattingApplied = false;
        }
    }
