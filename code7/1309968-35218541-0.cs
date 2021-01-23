    Conn.Open();
    
    DataSet ds = new DataSet();
    SqlCommand sqlCmd = new SqlCommand("SELECT * from CurrentDataCR ",Conn);
    
    using(SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd))
    {
        sqlDa.Fill(ds);
    }
    ds.Tables[0].Select("mst_remote_station_id Like '%9001%'");
