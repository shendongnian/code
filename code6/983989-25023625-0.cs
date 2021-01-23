    using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Registration1ConnectionString"].ConnectionString))
    {
        Conn.Open();
        using (SqlCommand cmd = Conn.CreateCommand())
        {
            cmd.CommandText = "select count(*) from [userdata] where UserName=@username";
            cmd.Parameters.AddWithValue(TextBoxuname.Text);
            int temp = (int)cmd.ExecuteScalar();
            if (temp.Equals(1))
            {
                Response.Write(" User Already Exists ");
            }
        }
    }
