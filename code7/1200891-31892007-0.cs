    string query = "select title, rating, dor from movie where title like '%"+name+"%';";
    
    using (SqlConnection conn = new SqlConnection(cs))
    {
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
    
        SqlDataReader reader = cmd.ExecuteReader();
    
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Response.Write(reader[0].ToString());
                Response.Write(reader[1].ToString());
                Response.Write(reader[2].ToString());
                Response.Write("------------------------");//whatever separator you want to use
            }
        }
        else
        {
            Response.Write("No rows found");
        }
    
        reader.Close();
    }
