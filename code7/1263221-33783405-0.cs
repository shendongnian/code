    public int GetMaxno(decimal Licenseno)
    {
         SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=True; Initial Catalog=sudipDB;");
         string sql = "select Max(Value) from tblv where Licenseno=@licenseno";
         SqlCommand cmd = new SqlCommand(sql, con);
         cmd.Parameters.AddWithValue("@Licenseno",Licenseno );
         con.Open();
         return (int)cmd.ExecuteScalar();
    }
