    public void loadSOCode()
     {
         DataSet ds = new DataSet();
         ds = db.getSOCode();
    
    
         if (ds.Tables[0].Rows.Count > 0)
         {
                ddlSoCode.DataSource = ds.Tables[0];
                ddlSoCode.DataTextField ="NewColumn";
                ddlSoCode.DataValueField = "NewColumn";
                ddlSoCode.DataBind();
    
                ddlSoCode.Items.Insert(0, new ListItem("--Select The Agent--", "--Select The Agent--"));
    
         }
    }
