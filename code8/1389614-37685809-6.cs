    string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public void ProcessRequest(HttpContext context)
        {
            string imageid = context.Request.QueryString["ImID"];
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(strcon);
            connection.Open();
            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("select Image from Image where ImageID=" + imageid, connection);
            System.Data.SqlClient.SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            connection.Close();
            context.Response.End();
        } 
