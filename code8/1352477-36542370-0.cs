    if(ds.Tables.Count >0)
    {
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        GridView2.DataSource = ds.Tables[1]; 
        GridView2.DataBind();
        GridView3.DataSource = ds.Tables[2];
        GridView3.DataBind();
    }
