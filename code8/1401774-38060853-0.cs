        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        int n;
        bool isNumeric = int.TryParse(e.FormattedValue.ToString(), out n);
        if (isNumeric)
        {
            //Code
        }
        else
        {
            e.Cancel = true;
        }
    }
