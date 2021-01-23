            using(OleDbConnection conn = new OleDbConnection(connString))
    {
            conn.Open();
            using(OleDbCommand cmd = new OleDbCommand()){
            DataTable table = null;
            cmd.Connection = conn;
 	table = new DataTable();
              cmd.CommandText = String.Format("SELECT SifraPacijenta, Ime, Prezime, DatumRodjenja, Adresa, Telefon FROM Pacijenti WHERE Ime + ' ' + Prezime LIKE '%{0}%' ORDER BY SifraPacijenta", tbPretragaImePrezime.Text);
               da = new OleDbDataAdapter(cmd);
               da.Fill(table);
    }
    }
                conn.Close();
            	gridPacijenti.DataSource = table;
