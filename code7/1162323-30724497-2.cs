    public void BindData()
    {
        SqlCommand comd = new SqlCommand("SELECT * FROM Yourtablename, con);
        SqlDataAdapter da = new SqlDataAdapter(comd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GV1.DataSource = dt;
        GV1.DataBind();
    }
   
