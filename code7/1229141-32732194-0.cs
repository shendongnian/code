    private void btnDelete_Click(object sender, EventArgs e)
    {
		var rowsRemoved = dataGridView1.Rows.Where(x => x.Cells["select"].Value == "yes");
		
		if (MessageBox.Show("Are you sure you want to delete " + rowsRemoved.Count() + " items ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
		{
			foreach(DataGridViewRow row in rowsRemoved)
			{
					sqlCommand1.CommandText = "DELETE FROM BARANG WHERE kode_barang = '" + row.Cells[0].Value.ToString() + "'";
					sqlConnection1.Open();
					sqlCommand1.ExecuteNonQuery();
					sqlConnection1.Close();
			}
		}
		else
		{
		}
		
       dataSet11.barang.Clear();
	   sqlDataAdapter1.Fill(dataSet11);
    }
