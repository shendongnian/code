    public void PerformAction()
    {
    if(Session["dlGlobal"]!=null)
     {
    DataList dlGlobal=Session["dlGlobal"] as DataList;
           string str = gstr;
        sq.connection();
        SqlCommand cmd = new SqlCommand("select top 4 * from comment where sid='" + str + "' order by my_date desc", sq.con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
    
        dlGlobal.DataSource = ds;
        dlGlobal.DataBind();
    }
    }
