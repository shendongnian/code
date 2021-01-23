    [WebMethod]
    public static void BindDropDownListData(int param)
    {//param is for nothing,     just parameter
        string cs = "server=.;uid=sam;pwd=p@ssw0rd;database=SSP";
        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select PCode,PName from SMSQUARE", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlprojects.DataSource = dt;
                ddlprojects.DataTextField = "PrjName";
                ddlprojects.DataValueField = "prjcode";
                ddlprojects.DataBind();
            }
            catch (Exception e)
            {
                Response.Write(e.Message.ToString());
            }
        }
    }
