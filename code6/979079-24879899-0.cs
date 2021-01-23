    public Product[] LoadAllDatas()
    {
        using (SqlConnection con = new SqlConnection(...))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("usp_LoadTestData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    List<Product> results = new List<Product>();
                    while (dr.Read())
                    {
                        results.Add(new Product { 
                             ProductId = Convert.ToInt32(dr["Id"]),
                             Name = dr["Name"].ToString(),
                             AdminContent = dr["AdminComment"].ToString(),
                             ProductTemplate = dr["ProductTemplateId"].ToString(),
                             CreatedOnUtc = Convert.ToDateTime(dr["CreatedOnUtc"])
                        });
                    }
                    return results.ToArray();
                }
            }
        }
    }
