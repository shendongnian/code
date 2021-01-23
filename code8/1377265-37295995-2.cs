    try
    {
        using (SqlConnection con = new SqlConnection(constr))
        {
            con.Open();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Image));
                cmd.Parameters.Add(new SqlParameter("@user", LoginName1.ToString()));
                cmd.CommandText = strQuery;
                cmd.ExecuteNonQuery();
            }
        }
    }
    catch(Exception ex)
    {
        //Handle your exception   
    }
