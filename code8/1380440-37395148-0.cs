    using(SqlConnection con  = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand("NewGETTDoc", con))
    {
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@EventID", SqlDbType.VarChar, 50).Value = EleIDLBL.Text.Trim();
        cmd.Parameters.Add("@AltSub", SqlDbType.Int).Value = Convert.ToInt32(Session["AltSubDocIdx"])+5;
        SqlParameter p = cmd.Parameters.Add("@new_identity", SqlDbType.Int)
        p.Direction = ParameterDirection.Output;
        int rowsAffected = cmd.ExecuteNonQuery();
        if(rowsAffected > 0)
        {
           int newID = Convert.ToInt32(p.Value); 
           ... do your task with the newID ....
        }
    }
