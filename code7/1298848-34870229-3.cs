    public List<Products> GetProducts(string productName, string productCode)
    {
       SqlConnection sqlconn = new SqlConnection(MyCachedSettings.ConnectionString);
       SqlCommand cmd = new SqlCommand("usp_Get_Products", sqlconn);
       .....
    }
