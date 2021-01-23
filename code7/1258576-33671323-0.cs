    public static class ProductsDataSource
     {
    public static DataTable LoadProducts()
     {
        using (SqlConnection conn = new   SqlConnection(ConfigurationManager.ConnectionStrings["Products_ConnectionString"].ConnectionString))
        using (SqlCommand command = new SqlCommand("SELECT * FROM Products_Table", conn))
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            return data;
        }
      }
    }
