    using (MySqlConnection cnn = new MySqlConnection("Server=;Database=OitDB;Uid=martin;Pwd=;"))
        {
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT namepc FROM skupina where nazovskup= 'mojask' ", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "skupina");
            List<string> skName = new List<string>();
            foreach (DataRow row in ds.Tables["skupina"].Rows)
            {
                skName.Add(row["namepc"].ToString());
                string constring = "Server=;Database=OitDB;Uid=martin;Pwd=;";
                var Query = "INSERT INTO OitDB.nrp(id,pc,ip,komu,datum,predmet,sprava,skupina)VALUES(@id,@pc,@ip,@komu,@cas,@predmet,@sprava,@name)";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@id", idtxt.Text);
                cmdDatabase.Parameters.AddWithValue("@pc", pc);
                cmdDatabase.Parameters.AddWithValue("@ip", label1.Text);
                cmdDatabase.Parameters.AddWithValue("@komu", comboBox1.Text);
                cmdDatabase.Parameters.AddWithValue("@cas", cas);
                cmdDatabase.Parameters.AddWithValue("@predmet", textBox1.Text);
                cmdDatabase.Parameters.AddWithValue("@sprava", pisat.Text);
                cmdDatabase.Parameters.Add("@name", MySqlDbType.VarChar).Value = row["namepc"];
                MySqlDataReader myReader;
                try
                {
                    conDatabase.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    MessageBox.Show("Správa odoslaná!");
                    while (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
