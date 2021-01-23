    private void iD_FurnizorComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        int id_furnizor;
        if(!int.TryParse(iD_FurnizorComboBox.Text, out id_furnizor))
        {
            MessageBox.Show("id_furnizor is not a valid integer: " + iD_FurnizorComboBox.Text);
            return;
        }
    
        using(var connection=new OleDbConnection("Connection String"))
        {
            try
            {
                string query = @"select f.* 
                                 from Furnizori f
                                 where id_furnizor = @id_furnizor;";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.Add("@id_furnizor", OleDbType.Integer).Value = id_furnizor;
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    numeTextBox.Text = reader.GetString(reader.GetOrdinal("nume"));
                    adresaTextBox.Text = reader.GetString(reader.GetOrdinal("adresa");
                    localitateTextBox.Text = reader.GetString(reader.GetOrdinal("localitate");
                    judetTextBox.Text = reader.GetString(reader.GetOrdinal("judet"));
                }
            } catch (Exception ex)
            {
                throw;  // redunant but better than throw ex since it keeps the stacktrace
            }
        }// not necessary to close connection, done implicitely
    }
 
