    try
         {
           SqlConnection con = new SqlConnection("user id=admin;" +
           "password=1337passwort;" +"server=localhost;" +
            "database=Aktiendepot; " +
             "connection timeout=30"); //Establishes Connection
         SqlCommand InsertStockInformation = new SqlCommand("StockBuy", con);
         InsertStockInformation.CommandType = CommandType.StoredProcedure;
         InsertStockInformation.Parameters.Add("@quantity",SqlDbType.Int).Value=quantity;
         InsertStockInformation.Parameters.Add("@symbol",SqlDbType.NVarChar,50).Value=sSymbol;
         InsertStockInformation.Parameters.Add("@company",SqlDbType.NVarChar,30).Value=sCompany;
         InsertStockInformation.Parameters.Add("@exchange",SqlDbType.NVarChar,20).Value=sExchange;
         InsertStockInformation.Parameters.Add("@buymktprice",SqlDbType.Float,50).Value=dPrice;
          InsertStockInformation.Parameters.Add("@username",SqlDbType.NVarChar,50).Value=sUsername;
     
    con.Open();
     InsertStockInformation.ExecuteNonQuery();
     
    con.Close();
     }
     catch(SqlException ex)
    {
      MessageBox.Show(ex.ToString());
                  
    }
