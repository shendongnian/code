    string commandText = "UPDATE MyTable SET EncryptedData = EncryptByPassPhrase(@DesKey, EncryptedData ) WHERE CustomerID = @ID";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@DesKey", SqlDbType.VarBinary);
        command.Parameters["@DesKey"].Value = TrippleDesKey;
        command.Parameters.Add("@ID", SqlDbType.Int);
        command.Parameters["@ID"].Value = customerID;
        try
        {
            connection.Open();
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
 
