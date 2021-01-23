        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //only update on column you are watching
            if (e.ColumnIndex.Equals(dataGridView1.Columns["ColumnName"].Index))
            {
                textBox1.Text = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            textBox1.Text = e.Row.Cells[dataGridView1.Columns["ColumnName"].Index].Value.ToString();
        }
        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            textBox1.Text = "Do something when value is deleted";
        }
