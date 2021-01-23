    private void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow item in dataGridView1.SelectedRows)
        {
           var id = item.Cells[0].Value.ToString();//You can change id and Cells[0] as your need
           //Write Delete code like this (Delete from Table where id = @id)
           dataGridView1.Rows.RemoveAt(item.Index);//Remove from dataGridView1
        }
    }
