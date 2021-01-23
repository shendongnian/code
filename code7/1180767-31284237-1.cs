    string strcon =ConfigurationManager.AppSettings["ConnectionString"].ToString();
    public void ProcessRequest(HttpContext context)
    {
    string imageid = context.Request.QueryString["ImID"];
    SqlConnection connection = new SqlConnection(strcon);
    connection.Open();
    SqlCommand command = new SqlCommand("select Image from Image where ImageID="+ imageid, connection);
    SqlDataReader dr = command.ExecuteReader();
    dr.Read();
    context.Response.BinaryWrite((Byte[])dr[0]);
    connection.Close();
    context.Response.End();
    }
