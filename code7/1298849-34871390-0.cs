    public List<Products> GetProducts(SqlConnection sqlconn, string productName, string productCode)
    {
       
    SqlCommand cmd = new SqlCommand("usp_Get_Products", sqlconn);
    
    }
    SqlConnection sqlconn = new SqlConnection("");
    sqlconn.Open();
    GetProducts(sqlconn, "productName", "code");
    GetProducts1(sqlconn, "productName", "code");
    sqlconn.Close();
