    string conString = "your connection string";
    SqlConnection con = new SqlConnection(conString);
    SqlParameter[] param = new SqlParameter[2];
    param[0] = new SqlParameter("@userid", userid);
    param[1] = new SqlParameter("@param2", param2);
    
    DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetUserData", param);
    GridView1.DataSource = ds;
    GridView1.DataBind();
