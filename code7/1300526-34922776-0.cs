    using (var con = new SqlConnection(connectionString))
    {
        con.Open();
         using (var cmd = new SqlCommand(@"INSERT INTO     OnlineProductsTemp$(CompetitorID, ProductCode, ProductName, DateCaptured)
        VALUES(@CompetitorID, @ProductCode, @ProductName, @DateCaptured)", con))
        {
             cmd.Parameters.Add("@CompetitorID", SqlDbType.Int);
             cmd.Parameters.Add("@ProductCode", SqlDbType.VarChar);
             cmd.Parameters.Add("@ProductName", SqlDbType.VarChar);
             cmd.Parameters.Add("@Price", SqlDbType.Decimal);
             cmd.Parameters.Add("@DateCaptured", SqlDbType.DateTime);
             for (int i = 0; i < competitorList.Count; i++)
             {
                 cmd.Parameters["@CompetitorID"].Value = competitorList[i];
                 cmd.Parameters["@ProductCode"].Value = productCodeList[i];
                 cmd.Parameters["@ProductName"].Value = productNameList[i];
                 cmd.Parameters["@Price"].Value = Decimal.Parse(productPriceList[i], <cultureInfoHere>);
                 cmd.Parameters["@DateCaptured"].Value = dateCapturedList[i];
                 int rowsAffected = cmd.ExecuteNonQuery(); // also the variable rowsAffected is not visible outside the scope of the for loop
             }
       }
    }
