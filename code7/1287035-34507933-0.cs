    public void bindgrid()
    {
                con = new SqlConnection(connStr);  
                con.Open();  
                da = new SqlDataAdapter("select * from Grid_Data", con);  
                Dataset ds = new DataSet();  
                da.Fill(ds);  
                GridView1.DataSource = ds;  
                GridView1.DataBind();  
    
    }
