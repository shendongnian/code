      public string GetLoggedUser(string User_Name)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HWebb"].ConnectionString);
        string UserName = "";
        try
        {
            SqlParameter[] parameters ={
                     new SqlParameter("@USER_CRED", User_Name),
                                       };
            SqlCommand cmd = CreateCommand("PortalWeb.GetSelect_User", parameters, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["USER_CRED"] != DBNull.Value)
                    UserName = Convert.ToString(dr["USER_CRED"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
        return UserName;
    }
