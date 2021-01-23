    using (SqlConnection con = new SqlConnection("your connection string"))
    {
       using (SqlCommand sc = new 
        SqlCommand("UPDATE Stockmaster SET Curbalqty= @q WHERE Stockno= @Stockno"))
       {
            sc.Parameters.AddWithValue("@Stockno", s);
            sc.Parameters.AddWithValue("@q", q);
        
            sc.Connection = con;
        
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
       }
    }
