    if (MessageBox.Show("Are you sure you want to delete this item ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            sqlConnection1.Open();
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                sqlCommand1.CommandText = "DELETE FROM BARANG WHERE kode_barang = '" + row.Cells[0].Value.ToString() + "'";
                sqlCommand1.ExecuteNonQuery();
            }
            sqlConnection1.Close();
        }
