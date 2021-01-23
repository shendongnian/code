    private void toolStripButton2_Click(object sender, EventArgs e)
    {
        MyProducts myProducts = new MyProducts();
        myProducts.ID = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        myProducts.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        myProducts.Quantity = Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        Form2 f2 = new Form2(this);
        f2.Product = myProducts;
        f2.Show();
    }
