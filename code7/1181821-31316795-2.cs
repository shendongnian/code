    DateTime dateSales = dateTimePicker1.Value;
    
    using(var con = new SqlConnection(Connection.connectionString()))
    using(var cmd = con.CreateCommand())
    {
        cmd.CommandText = "Insert into CarsSellout(CustomerID, dateSales) VALUES(@id, @date)";
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dateSales;
    
        con.Open();
        cmd.ExecuteNonQuery();
    }
