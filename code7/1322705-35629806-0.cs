    public string GetValue (string searchValue)
    {
      using(SqlConnection connection = new SqlConnection(connString));
      using(SqlCommand cmd = new SqlCommand(
         "select keyword from messageanalysis where value=@value")
      {
          cmd.AddParameter("@value",searchValue);
          var result = cmd.ExecuteScalar();
          return (result == null)? null : result.ToString();     
      
      }
    }
....
    var keyword = GetValue(value);
    if (keyword != null && value.Contains(keyword)){          
