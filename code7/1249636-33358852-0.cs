        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var val = this.dataGridView1[e.ColumnIndex,  e.RowIndex].Value.ToString();
            }
        }
