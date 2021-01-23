    var array = new string[10];
    
    var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    var check = new SqlCommand("select * from fees where admno = @admno", con);
    // Add your parameter value.
    
    var reader = check.ExecuteReader();
    
    int i = 0;
    while(reader.Read())
    {
       array[i] = reader.GetString(reader.GetOrdinal("tutionfee")); // I assume your tutionfee is the first column
       // And closest thing to varchar is string in .NET 
       i++;
    }
