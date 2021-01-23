    protected void UpdateDB(string user_id, string sid){
        SqlConnection con = new SqlConnection(your_connection_string);
        SqlCommand cmd = new SqlCommand("spProofStamp", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@USERID", SqlDbType.NVarChar).Value = user_id;
        cmd.Parameters.Add("@SID", SqlDbType.NVarChar).Value = sid;
        try{
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception ex){
            //process your exception
        }
        finally{
            con.Close();
            Response.Redirect(Request.Url.AbsoluteUri); //refresh this page
        }
    }
