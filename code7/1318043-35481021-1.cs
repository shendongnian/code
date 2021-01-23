    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dataGridView1.Columns["columnName"].Index && e.RowIndex >= 0)
        {
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                int value = int.Parse(dataGridView1.Rows[j].Cells["columnName"].Value.toString())
                if ( value > 1 && value < 10)
                {
                    //Some Code;
                }
                else
                {
                    MessageBox.Show("Error Message");
                }
            }
        }
    }
