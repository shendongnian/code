        var conn = new SQLiteConnection("data source=db");
        conn.Open();
        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select * from customers";
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                MessageBox.Show(rdr["name"].ToString());
            }
            
        }
