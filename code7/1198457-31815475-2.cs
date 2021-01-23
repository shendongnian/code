    using (SqlCeConnection conn =
    new SqlCeConnection(@"Data Source=C:\Users\FluksikartoN\Documents\Visual Studio 2012\Projects\BuroFoki\BuroFoki\MainDB.sdf"))
    using (SqlCeCommand cmd = conn.CreateCommand())
    {
        conn.Open();
        //commands represent a query or a stored procedure       
        cmd.CommandText = "SELECT buyEURrate FROM CurrencyRates";
        using (SqlCeDataReader rd = cmd.ExecuteReader())
        {
           while(rd.Read())
           {
               double variable = Convert.ToDouble(rd[0]);
               string foo = rd.GetString[1];
               //do something with variable and foo before going to next row in query
           }
        }
        conn.Close();
    }
