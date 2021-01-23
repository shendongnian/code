	private void button1_Click(object sender, EventArgs e)
	{
		string ett = textBox1.Text;
		if (ett == "")
		{
			MessageBox.Show("Du måste fylla i UID, vilket du finner i användarlistan.");
			return;
		}
		try
		{
			db_connection(); //added this line
			if (connect.State == ConnectionState.Open)
			{
				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = connect;
				cmd.CommandText = "DELETE FROM Users WHERE uid = @uid";
				cmd.Parameters.AddWithValue("@uid", textBox1.Text);
				MySqlDataReader accessed = cmd.ExecuteReader();
				MessageBox.Show("Användaren borttagen.");
			}
			else
			{
				MessageBox.Show("Något gick tyvärr fel, kontakta systemadministratören.");
			}
		}
		catch (Exception ex)
		{
            MessageBox.Show(ex.Message);
        }	
    }
