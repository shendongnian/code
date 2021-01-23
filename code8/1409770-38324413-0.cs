    [WebMethod]
    public List<cityPopulation> getCityPopulation(List<string> aData)
    {
        List<cityPopulation> p = new List<cityPopulation>();
    
        string myQuery = "SELECT cityname, population FROM  tblcitypopulation WHERE  year = @year";
    
        using (SqlConnection cn = new SqlConnection("server=.....;user id=sa;password=...;database=Example"))
        using (SqlCommand cmd = new SqlCommand(myQuery, cn))
        {
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = aData[0];
    
            cn.Open();
    
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                     cityPopulation cpData = new cityPopulation();
                     cpData.cityname = dr["cityname"].ToString();
                     cpData.population = Convert.ToInt32(dr["population"].ToString());
    
                     p.Add(cpData);
                }
            } 
            return p;
        }
    }
