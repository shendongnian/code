    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            int i;
            if (!string.IsNullOrEmpty(e.FormattedValue)  && !int.TryParse(Convert.ToString(e.FormattedValue), out i))
            {
                e.Cancel = true;
                label1.Text ="please enter numeric";
            }
            else
            {
            }
        }
    }
