    public void ProcessRequest (HttpContext context) {
        try
        {
            string empcd = context.Request.QueryString["empcd"].ToString();
            string conStr = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select photo from mytable where id = @empcd", con);
            cmd.Parameters.Add("@empcd", SqlDbType.Int).Value = empcd;
            con.Open();
            string data = cmd.ExecuteScalar().ToString();
            con.Close();
            cmd.Dispose();
            context.Response.BinaryWrite(Convert.FromBase64String(data));
        }
        catch (Exception ex)
        {
            //if some exceptions will occur
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
