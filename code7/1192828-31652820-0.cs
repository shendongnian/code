    var imageIdParam = Request.QueryString["ImageID"];
    if (imageIdParam != null)
    {
        var imageId = imageIdParam == "" ? -1 : Convert.ToInt32 (imageIdParam);
        var cmd = new SqlCommand();
        var strQuery = "select TOP 1 Name, ContentType, Data from stock ";
        if(imageId > 0) {
            strQuery += "where id=@id ";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = imageId;
        }
        strQuery += "order by id DESC";
        cmd.CommandText = strQuery;
        DataTable dt = GetData(cmd);
        if (dt != null)
        {
            Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["ContentType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Name"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
