         SqlCommand cmd = new SqlCommand("SELECT ItypeNo FROM tbl_itemMaster WHERE Itype = @USUsername",connectionSTringHere);
         
        cmd.Parameters.Add("@USUsername", SqlDbType.VarChar).Value = recv.Itypes;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.fill(ds);
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            itemNo = Convert.ToInt32(dr["ItypeNo"].ToString());
        }
        return itemNo;
