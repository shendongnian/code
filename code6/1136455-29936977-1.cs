    using (var conn = new SqlConnection(this.ConnectionString))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "House_GetHouseById";
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.Parameters["@HouseId"].Value = houseId;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // do something
                }
            }
        }
    }
