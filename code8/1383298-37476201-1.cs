	public void ProcessRequest (HttpContext context)
    {
		OracleDataReader rdr = null;
        OracleConnection conn = Conn.getConn();
        OracleCommand cmd = null;
        string ImgType = context.Request.QueryString["typ"].ToString();
        try
        {
            if (ImgType=="edu")//this is working fine
            {
                cmd = new OracleCommand("select attachment pic from newtbl where lvldcp_code=" + context.Request.QueryString["dcp"] + "and emp_code="+context.Request.QueryString["emp"], conn);
            }
            else if (ImgType=="profile")
            {
                cmd = new OracleCommand("select photo pic from oldtbl where emp_code="+context.Request.QueryString["emp"], conn);
            }
			
			Byte[] byteArray = null;
			OracleBlob blob;
            conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
				blob = rdr.GetOracleBlob(0);
				byteArray = new Byte[blob.Length];
				int i = blob.Read(byteArray, 0, System.Convert.ToInt32(blob.Length));
				
				//clob.Length or i > 0 will show if there are bites in the clob or not
            }
            if (rdr != null)
                rdr.Close();
				
			context.Response.ContentType = "image/jpg";
			context.Response.BinaryWrite(byteArray);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
		
	}
