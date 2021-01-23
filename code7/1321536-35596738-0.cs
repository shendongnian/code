    public void InsertProduct(int categoryId, string name, string description, decimal price)
    {
        String sc = ConfigurationManager.ConnectionStrings["BDCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(sc))
        {
            con.Open(); 
            using (SqlCommand cmd = new SqlCommand("spInsertNewProductByCategoryId", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CategoryId").Value = categoryId;
                cmd.Parameters.Add("@ProductName").Value = name;
                cmd.Parameters.Add("@ProductDescription").Value = description;
                cmd.Parameters.Add("@ProductPrice").Value = price;
                cmd.ExecuteNonQuery();
            }
        }
    }
