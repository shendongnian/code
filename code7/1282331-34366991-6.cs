    var tvp = new DataTable();
    tvp.Columns.Add("Id", typeof(int));
    foreach(var id in RecIdsToDelete)
        tvp.Rows.Add(new {id});
          
    var connection = new SqlConnection("your connection string");
          
    var delete = new SqlCommand("your stored procedure name", connection)
    {
      CommandType = CommandType.StoredProcedure
    };
    delete
      .Parameters
      .AddWithValue("@ids", tvp)
      .SqlDbType = SqlDbType.Structured;
    delete.ExecuteNonQuery();
