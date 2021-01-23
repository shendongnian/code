     string id = GV.DataKeys[e.NewEditIndex].Value.ToString();
        string select = "select * from tblLogin where id ='"+Convert.ToInt16(id)+"'";
        ds = gs.select(select);
        if (ds.Tables[0].Rows.Count > 0)
        {
           lblName.Text= ds.Tables[0].Rows[0]["Column1"].ToString();
            lblPass.Text=ds.Tables[0].Rows[0]["Column2"].ToString();
        }
