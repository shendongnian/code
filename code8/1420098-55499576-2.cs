     protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    // Enable the GridView paging option and  
                    // specify the page size. 
                    gridEvent.AllowPaging = true;
                    gridEvent.PageSize = 15;
    
                    // Initialize the sorting expression. 
                    ViewState["SortExpression"] = "EventId ASC";
                    // Enable the GridView sorting option. 
                    gridEvent.AllowSorting = true;
                    BindGrid();
                }
            }
            private void BindGrid()
            {
                // Get the connection string from Web.config.
        // When we use Using statement,  
        // we don't need to explicitly dispose the object in the code,  
        // the using statement takes care of it. 
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ToString()))
                {
                    // Create a DataSet object. 
                    DataSet dsPerson = new DataSet();
    
    
                    // Create a SELECT query. 
                    string strSelectCmd = "SELECT * FROM EventsList";
    
    
                    // Create a SqlDataAdapter object 
                    // SqlDataAdapter represents a set of data commands and a  
                    // database connection that are used to fill the DataSet and  
                    // update a SQL Server database.  
                    SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
    
    
                    // Open the connection 
                    conn.Open();
    
    
                    // Fill the DataTable named "Person" in DataSet with the rows 
                    // returned by the query.new n 
                    da.Fill(dsPerson, "EventsList");
    
    
                    // Get the DataView from Person DataTable. 
                    DataView dvPerson = dsPerson.Tables["EventsList"].DefaultView;
    
    
                    // Set the sort column and sort order. 
                    dvPerson.Sort = ViewState["SortExpression"].ToString();
    
    
                    // Bind the GridView control. 
                    gridEvent.DataSource = dvPerson;
                    gridEvent.DataBind();
                }
            }
            //Implementing Pagination
            protected void OnPaging(object sender, GridViewPageEventArgs e)
            {
                gridEvent.PageIndex = e.NewPageIndex;
                gridEvent.DataBind();
            }
