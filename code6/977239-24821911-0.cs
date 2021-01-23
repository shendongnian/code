    private void gridViewTimes_CellLeave(object sender, DataGridViewCellEventArgs e)
    {
        if(dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
        {
            string value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
