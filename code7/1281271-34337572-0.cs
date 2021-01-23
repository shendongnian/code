    public bool Delete(string id, string column, string table)
    {
      using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
         conn.Open();
         var query = String.Format("DELETE FROM {0} WHERE {1}='{2}'", table,column, id)
         using (SqlCommand cmd = new SqlCommand(query))
         {
              cmd.ExecuteNonQuery();
         }
      }
    }
