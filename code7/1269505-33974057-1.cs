    string businessId = Session["businessid"].ToString();
    string referenceNo = Session["referenceno"].ToString();    
    bool hasRows = false;    
    
    using(SqlConnection connection = new SqlConnection(parameters))
    {
        using(SqlCommand checkCommand = new SqlCommand("select * from quoted_price where businessid=@businessid AND refno=@refno", connection))
        {
            check.Parameters.AddWithValue("@businessid", businessId);
            check.Parameters.AddWithValue("@refno", referenceNo);
            connection.Open();
            using(SqlDataReader dataReader = check.ExecuteReader())
            {
                 hasRows = dataReader.HasRows;
            }                   
        }
    }
