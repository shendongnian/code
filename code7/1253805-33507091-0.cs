    public void obtener (List<Models.Producto> prods)
    {
        try
        {
            CreateConnection();
            mSqlCommand = new SqlCommand();
            mSqlCommand.Connection = mSqlConnection;
            mSqlCommand.CommandText = "SP_GetProd";
            mSqlCommand.CommandType = CommandType.StoredProcedure;
            using(SqlDataReader reader = mSqlCommand.ExecuteReader())
            {
                while(reader,Read())
                {
                     Models.Producto aSingleProd = new Models.Producto();
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
