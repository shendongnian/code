    try
    {
        using (myConnection)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = myConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = "IF EXISTS (SELECT * FROM dbo.PopularityPokemon WHERE Dex_ID = @Dex_ID) UPDATE dbo.PopularityPokemon SET TimesPicked = TimesPicked + @PickCount"
                    + "ELSE" 
                    + "INSERT into dbo.PopularityPokemon (Dex_ID, TimesPicked)"
                    + "VALUES(@Dex_ID, @PickCount)";
                command.Parameters.AddWithValue("@Dex_ID", dexID);
                command.Parameters.AddWithValue("@PickCount", _pickCount);
                command.ExecuteNonQuery();
            }
        }
    }
