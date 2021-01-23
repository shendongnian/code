    protected string ProgTitle;
    public string ProgramsDetails()
    {
        using (SqlConnection con = new SqlConnection(str))
        {
            string htmlStr = "";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = " SELECT * from programs where ProgId=@ProgId";
            cmd.Parameters.AddWithValue("@ProgId", "1");
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int ProgId = reader.GetInt32(0);
                ProgTitle = reader.GetString(1);
                string ProgBudget = reader.GetString(4);
                string ProgStarDate = reader.GetString(5);              
            }
            con.Close();
            return htmlStr;
        }
    }
