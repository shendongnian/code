	 protected void Button2_Click(object sender, EventArgs e)
	 {
		string st = "SELECT F_L FROM split_master";
		cmd = new SqlCommand(st, sqlcon);
		cmd.Connection.Open();
		SqlDataReader sqlread = cmd.ExecuteReader();
		cmd.Connection.Close();
		while(sqlread.Read()){
			string[] word = sqlread["F_L"].ToString().Split();
			for (int count = 0; count <= word.Length; count++)
			{
				MessageBox.Show(word[count]);
			}
		}
	  }
