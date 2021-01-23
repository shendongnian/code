    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductImagesID"] != null)
        {
    string query = "Select ProductImage from ProductImages where ProductImageId = @ProductImageId";
    SqlCommand cmd = new SqlCommand(query,YourConnectionObject);
        cmd.Parameters.AddWithValue("@ProductImageId", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["ProductImagesID"]);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        
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
