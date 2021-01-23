    public class FileStreamHandler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["id"]);
            byte[] bytes;
            string contentType;
            string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            string name;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand("[EPORTAL].[LearnerLoginGetEvidenceFile]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EvidenceID", id);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        name = sdr["Name"].ToString();
                        con.Close();
                    }
                }
                context.Response.Clear();
                context.Response.Buffer = true;
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
                context.Response.ContentType = contentType;
                context.Response.BinaryWrite(bytes);
                context.Response.End();
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
