    SqlConnection cn = new SqlConnection("Data Source = localhost; Initial Catalog = CinemaProj; Integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT IMAGE FROM t_TableName WHERE ID=1", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cn.Open();
           DataSet ds = new DataSet();
           da.fill(ds);
    
        foreach(DataRow dr in ds.Table[0].Rows)
        {
            imgByte = (byte[])(dr["Image"]);
        }
        string strBase64 = Convert.ToBase64String(imgByte);
