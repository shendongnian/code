    var conString = ...;
    var query = "UPDATE TEST SET Val ='XYZ' OUTPUT INSERTED.* WHERE Val = @Val";
    using (SqlConnection con = new SqlConnection(conString))
    {
        con.Open();
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Val", "ABC");
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["Val"]);
                }
            }
        }
