    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        string sql = @" SELECT id, name, path FROM Images where id = @id";
        using (SqlCommand comm = new SqlCommand(sql, conn))
        {
            comm.Parameters.AddWithValue("@id", id);           
            using (var reader = await comm.ExecuteReaderAsync())
            {
                int ordId = reader.GetOrdinal("id");
                int ordName = reader.GetOrdinal("name");
                int ordPath = reader.GetOrdinal("path");
                if (!reader.Read())
                     throw new Exception("Something is very wrong");
                image.Id = reader.GetInt32(ordId);
                image.Name = reader.GetString(ordName);
                image.Path = reader.GetString(ordPath);
                return image;
            }
        }
    }
