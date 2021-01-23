            string selectAll = "SELECT * FROM tblUser";        //new query to execute
            string oldSelect = SqlDataSource1.SelectCommand;    //stores old query in temp variable
            SqlDataSource1.SelectCommand = selectAll;           //sets the SelectCommand of the DataSource to the new query
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);    //executes the SelectCommand
            GridView1.DataSourceID = "";
            GridView1.DataSource = SqlDataSource1;
            
            GridView1.DataBind();                              //binds the GridView to the DataSource
            SqlDataSource1.SelectCommand = oldSelect;   
