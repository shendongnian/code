    public DataTable getData(string query)
    {
         DataTable dtable = new DataTable();
         using (SqlConnection con = new SqlConnection(YourConnectionString)){
             using (SqlCommand cmd = new SqlCommand(query,con){
                  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                  return adapter.Fill(dt);
             } 
         }
    }
