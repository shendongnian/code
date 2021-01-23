    DataTable dt = new DataTable();
            mySqlDataAdapter.Fill(dt);
            int socot = dt.Rows.Count;
            for (int i = 0; i < socot; i++)
            {
                String dn = dt.Rows[i][1].ToString();
                String gduan = "SELECT tennha FROM duannha WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = gduan;
                cmd.Parameters.AddWithValue("@id", dn);
                String gtennha = cmd.ExecuteScalar().ToString();
                int a;
                int.TryParse(gtennha.Split(' ')[1], out a);
                dt.Rows[i][1] = a;
            }
