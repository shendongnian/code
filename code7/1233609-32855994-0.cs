    public static bool logarUsuario(string user, string pw)
    {
     const string checkUser = 
       @"SELECT COUNT(*) FROM tbUsuario 
          WHERE userName = @u AND pw = @p";
     using (SqlConnection con = Banco.con())
     {
       con.Open();
       SqlCommand cmd = new SqlCommand(checkUser, con);
       cmd.Parameters.AddWithValue("@u", user);
       cmd.Parameters.AddWithValue("@p", pw);
       return 1 == (int) cmd.ExecuteNonQuery();
     }
    }
