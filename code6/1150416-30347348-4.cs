    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            POS POS = new POS();
            POS.txtProductCode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            POS.txtProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            POS.Show();
        }
