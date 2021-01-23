    namespace Product
    {
        class Program
        {
            static void Main(string[] args)
            {
                 SqlConnection conn = new SqlConnection(
                     "Data Source=localhost\\Win;Initial Catalog=Databasee; Integrated Security=True");
    
                 string sql =
                     "INSERT INTO Products " +
                     "(Description)" +
                     "Values (@Description)";
                    
                 string toxin = "''); DELETE FROM Products; --";
    
                 SqlCommand sqlCommand = new SqlCommand(sql, conn);
                 sqlCommand.Parameters.AddWithValue("@Description", toxin);
                 conn.Open();
                 sqlCommand.ExecuteNonQuery();
                 conn.Close();
            }
    
         }
     }
