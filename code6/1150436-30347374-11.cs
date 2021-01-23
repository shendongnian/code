    private POS pos;
    // Constructor of ProductListForm
    public ProductListForm(POS pos)
    {
        this.pos = pos;
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        pos.txtProductCode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        pos.txtProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        this.Close();
    }
