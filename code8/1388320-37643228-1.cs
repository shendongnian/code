	for(int i = dgvPretraga.RowCount-1; i >= 0; i--){
		var row = dataGridView1.Rows[i];
		naziv = row.Cells["naziv"].Value.ToString();
		if (naziv.Contains(txtNaziv.Text))
		{
			Console.WriteLine("Yup = " + naziv);
		}
		else
		{
			 dgvData.Rows.Remove(dgvPretraga.Rows[i]);
			Console.WriteLine("Not = " + naziv);
		}
	}
