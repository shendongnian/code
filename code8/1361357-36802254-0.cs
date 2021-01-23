    DataTable dt = new DataTable();
    string query = string.format("SELECT * from table WHERE ID = {0}", ID);
    using(SqlDataAdapter sda = new SqlAdapter(query, con))
    {
         sda.fill(dt)
         if(dt.Rows.count > 0)
         {
             showErrorMessage();
             return;
         }
    }
