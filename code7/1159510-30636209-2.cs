    var array = new string[10];
    
    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    using(var check = new SqlCommand("select * from fees where admno = @admno", con))
    {
        // Add your parameter value.
    
        using(var reader = check.ExecuteReader())
        {
           int i = 0;
           while(reader.Read())
           {
              array[i] = reader.GetString(reader.GetOrdinal("tutionfee")); 
              i++;
           }
        }
    }
