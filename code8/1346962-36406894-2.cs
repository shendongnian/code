    // Set the command text (you could pass this in the constructor)
    sqlcom.CommandText = "select * from table1 where loc = @loc ";
    // Create SqlParameter
    // Note that I don't know your actual SqlDbType, replace it with whatever it should be
    SqlParameter param = new SqlParameter("@loc", SqlDbType.Varchar) { Value = loc };
    // Add to SqlCommand parameter collection
    sqlcom.Parameters.Add(param);
    // Add the command to your SqlDataAdapter if you are using one
