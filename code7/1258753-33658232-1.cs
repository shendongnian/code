    public static class YourDataSource
    {
        public static DataTable LoadSomeData()
        {
            using (SqlConnection conn = new SqlConnection("your connection string here"))
            using (SqlCommand command = new SqlCommand("SELECT * FROM TestTable", conn))
            {
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                return data;
            }
        }
    }
