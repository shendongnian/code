    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                myCon.Open();
                OleDbCommand cmd1 = new OleDbCommand("SELECT sum_stock_purchase_quantity, sum_stock_purchase_quantity_thaan from productPurchaseQuery where stock_product_id=" + this.dataGridView1.CurrentCell.Value.ToString() + "");
                
                cmd1.Connection = myCon;
                OleDbDataReader reader = null;
                reader = cmd1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        textBox9.Text = Convert.ToString(reader["sum_stock_purchase_quantity"]);
                        textBox2.Text = Convert.ToString(reader["sum_stock_purchase_quantity_thaan"]);
                    }
                }
                else
                {
                    textBox9.Text = "0.0";
                    textBox2.Text = "0.0";
                }
                myCon.Close();
