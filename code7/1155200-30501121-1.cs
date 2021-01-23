    public static SqlDataReader reader(string query)
    {
        SqlConnection con = new SqlConnection(constring());
    
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
    
        return cmd.ExecuteReader();
    }
