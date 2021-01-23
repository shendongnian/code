    public void obtener (List<Models.Producto> prods)
    {
        try
        {
            CreateConnection();
            mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mSqlConnection;
            mSqlCommand.CommandText = "SP_GetProd";
            mSqlCommand.CommandType = CommandType.StoredProcedure;
            // Here the SP will be executed and the result is ready
            using(SqlDataReader reader = mSqlCommand.ExecuteReader())
            {
                // Move the reader on the first/next record until there are records
                while(reader,Read())
                {
                     // Create one empty Producto 
                     Models.Producto aSingleProd = new Models.Producto();
                     // Set every property of the Producto with the 
                     // values from the fields returned by the SP
                     aSingleProd.Property1 = reader["Field1"].ToString();
                     .... other property of your Producto
                     prods.Add(aSingleProd);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
