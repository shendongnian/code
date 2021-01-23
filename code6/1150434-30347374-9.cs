    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        POS pos = (POS)this.Owner;
        pos.txtProductCode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        pos.txtProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        this.Close();
    }
