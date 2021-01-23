    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int RowIndex = dataGridView1.SelectedRows[0].Index;
                if (dataGridView1.Rows[RowIndex].DefaultCellStyle.ForeColor == Color.Black)
                {
                    MessageBox.Show("This row font is Black");
                }      
            }
        }
  
