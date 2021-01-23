        var conn = new SQLiteConnection("data source=db");
        conn.Open();
        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select * from contracts";
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                MessageBox.Show(rdr[0].ToString());
            }
            
        }
