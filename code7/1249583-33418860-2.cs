    class DataLayer
    {
        public const string ConnectionString = "my connection string";
        internal List<string> RetrieveCatagories()
        {
            List<string> items = new List<string>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string select_string = "SELECT * FROM dbo.Categories";
                SqlCommand cmd = new SqlCommand(select_string, con);
                con.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    items.Add(myReader[1].ToString());
                }
                myReader.Close();
            }
            return items;
        }
        
    }
