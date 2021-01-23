    private string[] getobject(string source, SqlConnection conn)
    {
       var command = new SqlCommand("select * from ABC");
       var reader = command.ExecuteReader();
       var output = new List<string>();
       while(reader.Read())
       {
           output.Add(reader.GetString(1));
       }
          return output.ToArray();
    }
