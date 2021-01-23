    private bool isDisabled(string favoriet)
    {
        using (var connection = createConnection())
        {
            using (var cmd = new connection.CreateCommand())
            {
                cmd.CommandText = "Select disabled from leerling where leerlingnummer = @number";
                cmd.Parameters.AddWithValue("@number", favoriet);
                // for simplicity I have assumed that it will always find a value. This should be checked
                var disabled = Convert.ToBoolean(cmd.ExecuteScalar());
                return disabled;
            }
        }
    }
