    SQL connection code for connecting database...
    public static void sqlUploadContactInfoData(string[] Userdata)
        {
            using (SqlConnection sqlConn = jPortalDBConnection())
            {
                try
                {
                    sqlConn.Open();
                    string spName = "spUploadContactInfoData";
                    SqlCommand cmd = new SqlCommand(spName, sqlConn);
                    cmd.Parameters.AddWithValue("@txtCnct", txtCnct.Text);
                    cmd.Parameters.AddWithValue("@txtAltCnct", txtAltCnct.Text);
                    cmd.Parameters.AddWithValue("@txtEmrCnct",  txtEmrCnct.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlConn;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    ErrorMsg("Server Error", "Server Error ! Please try again Later.");
                }
            }
        }
