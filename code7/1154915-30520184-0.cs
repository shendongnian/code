        private void dgvVX130DataErrors(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewComboBoxColumn comboColumn;
            switch (e.ColumnIndex)
            {
                case 4:
                    comboColumn = ((DataGridViewComboBoxColumn)dgvVX130.Columns["DataDomain"]);
                    if (!comboColumn.Items.Contains(dgvVX130.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                    {
                       comboColumn.Items.Add(dgvVX130.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    }
                    break;
