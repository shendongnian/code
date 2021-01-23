    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                POS POS = new POS();
                string ProductCode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string ProductName= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                POS.FillTextBoxes(ProductCode, ProductName);
                POS.Show();
            }
