    public static SqlDataReader reader(string query)
    {
        SqlConnection con = null;
    
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
    
        return cmd.ExecuteReader();
    }
