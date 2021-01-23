       protected void Page_Load(object sender, EventArgs e)
        {
            //to make sure the data isn't loaded in postback
            if (!Page.IsPostBack)
            {
                //use a datatable for storing all the data
                DataTable dt = new DataTable();
                string query = "SELECT * FROM myTable ORDER BY myColumn DESC";
                //wrapping in 'using' means the connection is closed an disposed when done
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    try
                    {
                        //fill the datatable with the contents from the database
                        adapter.Fill(dt);
                    }
                    catch
                    {
                    }
                }
                //save the datatable into a viewstate for later use
                ViewState["myViewState"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.ToLower();
            //check if the search input is at least 3 chars
            if (searchTerm.Length >= 3)
            {
                //always check if the viewstate exists before using it
                if (ViewState["myViewState"] == null)
                    return;
                //cast the viewstate as a datatable
                DataTable dt = ViewState["myViewState"] as DataTable;
                //make a clone of the datatable
                DataTable dtNew = dt.Clone();
                //search the datatable for the correct fields
                foreach (DataRow row in dt.Rows)
                {
                    //add your own columns to be searched here
                    if (row["field01"].ToString().ToLower().Contains(searchTerm) || row["field02"].ToString().ToLower().Contains(searchTerm))
                    {
                        //when found copy the row to the cloned table
                        dtNew.Rows.Add(row.ItemArray);
                    }
                }
                //rebind the grid
                GridView1.DataSource = dtNew;
                GridView1.DataBind();
            }
        }
        protected void resetSearchButton_Click(object sender, EventArgs e)
        {
            //always check if the viewstate exists before using it
            if (ViewState["myViewState"] == null)
                return;
            //cast the viewstate as a datatable
            DataTable dt = ViewState["myViewState"] as DataTable;
            //rebind the grid
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
