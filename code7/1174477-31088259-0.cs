    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string sql1 = "SELECT Image FROM" +
                " YourTableName WHERE faqid=" +  Convert.ToInt32(Request.QueryString["id"].ToString());
    
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "your connection string";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0] != DBNull.Value)
                {
                    Byte[] bytes = (Byte[])dr[0];
                }
                else
                {
                    byte[] bytes = ReadFile(Server.MapPath("~/images/empty.PNG"));
                    Response.Buffer = true;
                }
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
    
            dr.Close();
            conn.Close();
    
        }
    }
    byte[] ReadFile(string sPath)
    {
        byte[] data = null;
        FileInfo fInfo = new FileInfo(sPath);
        long numBytes = fInfo.Length;
        FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fStream);
        data = br.ReadBytes((int)numBytes);
        return data;
    }
