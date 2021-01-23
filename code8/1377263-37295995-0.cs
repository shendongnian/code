    using (SqlConnection con = new SqlConnection(constr))
    {
        con.Open();
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@data", SqlDbType.Image).Value = bytes;
            cmd.Parameters.AddWithValue("@user", LoginName1.ToString());
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }
    }
