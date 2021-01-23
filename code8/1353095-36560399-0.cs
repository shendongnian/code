    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	DataTable dt = new DataTable();
        SqlDataAdapter Adpt;
        if(DropDownList1.SelectedValue == string.Empty)
        {
            //If you want to return a blank DataGrid then the code below is fine else add 
    		//return; 
    		GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        if(DropDownList1.SelectedValue == "db1")
        {
    		SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db1ConnectionString"].ConnectionString);
    		SqlCommand cmd = new SqlCommand("select db1.dbo.table1.dbname where dbname = 'testdb1' ", con);
    		Adpt = new SqlDataAdapter(cmd);
    		Adpt.Fill(dt);
    		GridView1.DataSource = dt;
    		GridView1.DataBind();
        }
        else if(DropDownList1.SelectedValue == "db2")
        {
    		SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db2ConnectionString"].ConnectionString);
    		SqlCommand cmd = new SqlCommand("select db2.dbo.table1.dbname where dbname = 'testdb2' ", con);
    		Adpt = new SqlDataAdapter(cmd);
    		Adpt.Fill(dt);
    		GridView1.DataSource = dt;
    		GridView1.DataBind();
        }
    }
