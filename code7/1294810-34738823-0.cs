    private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
            int index = e.RowIndex;
    
            Form2 newForm = new Form2();
            newForm.H_id = dataGridView.Rows[index].Cells[0].Value;
            newForm.Serie = dataGridView.Rows[index].Cells[1].Value;
            newForm.Numar = dataGridView.Rows[index].Cells[2].Value;
            newForm.Partener = dataGridView.Rows[index].Cells[3].Value;
            newForm.Data = Convert.ToDateTime(dataGridView.Rows[index].Cells[4].Value);         
            newForm.Show();
            }
