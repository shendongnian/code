        private void Form_Shown(object sender, EventArgs e)
        {
            dataGridView.ColumnWidthChanged += dataGridView_ColumnWidthChanged;
        }
        
        private void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            // it's the user who clicked!!
        }
