    protected void Button1_Click(object sender, EventArgs e)
     {
       MSConnector connector = new MSConnector();
       connector.ConnectionString = "SERVER=xbetasql,52292;UID=username;Password=secret;DATABASE=ATDBSQL;";
    
       DataSet selectedAngels = connector.ExecuteQuery("select * from customer where idcustomer = 453433");
       DataTable dt = selectedAngels.Tables[0];
       data.DataSource = dt;
       data.DataBind();
       }
