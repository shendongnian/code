    private void button2_Click(object sender, EventArgs e)
	{
		//Datetimepicker to Database
		string dProduksi = DateTime.Parse(dtmProduksi.Text).ToString("yyyy-MM-dd");
		try
		{
			con.Open();
			cmd = new SqlCommand("insert into Produksi (IDProduksi,IDPhoto,TanggalProduksi,NamaKaryawan,KeteranganPhoto) Values('" + txtIdpro.Text + "','" + txtIdPhoto.Text + "','" + dProduksi + "','" + txtNamaKaryawan.Text + "','" + rxtKtrphoto.Text + "')", con);
			cmd.ExecuteNonQuery();
			MessageBox.Show("Update telah di jalankan");
			con.Close();
			showgridview();
			clear();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
