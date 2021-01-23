	foreach(DataGridViewRow row in dgvPretraga.Rows)
    {
		naziv = row.Cells["naziv"].Value.ToString();
		if (naziv.Contains(txtNaziv.Text))
		{
			Console.WriteLine("Yup = " + naziv);
		}
		else
		{
			// dgvPretraga.Rows.Remove(row);
			Console.WriteLine("Not = " + naziv);
		}
	}
	
