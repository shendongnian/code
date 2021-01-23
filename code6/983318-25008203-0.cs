    try
    {
        string connectionString = @" Data Source = c:\milap\milap.s3db; Version = 3";
    
        using (var conn = new SQLiteConnection(connectionString))
        {
            using (var cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select VC1ON from table where trim(key)= @KEY";
    
                conn.Open();
    
                cmd.Parameters.AddWithValue("@KEY", key.Text);
                var reader = cmd.ExecuteReader();
    
                while (reader.Read())
                    ON1.Text = reader["VC1ON"].ToString();
            }
        }
    }
    catch (Exception ex)
    {
         MessageBox.Show(ex.Message);
    }
