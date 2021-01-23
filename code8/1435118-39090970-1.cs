    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ImageID"] != null)
        {
    SqlConnection conn = new SqlConnection("DataSource=localhost; Database=varbinary; User ID=****; Password=****");
             SqlCommand comm = new SqlCommand();
             comm.Connection = conn;
    
             comm.CommandText = "select * from files where FileId=@id";
             comm.Parameters.AddWithValie("@id", Convert.ToInt32(Request.QueryString["ImageID"]);
             SqlDataAdapter da = new SqlDataAdapter(comm);
             DataTable dt = new DataTable();
    
             da.Fill(dt);
           
            if (dt != null)
            {
                Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = dt.Rows[0]["ContentType"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + dt.Rows[0]["Name"].ToString());
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
