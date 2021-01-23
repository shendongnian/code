    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   DataTable dtSource = new DataTable();
                        dtSource.Columns.Add("DateTime");
                        dtSource.Columns.Add("Detail");
                        dtSource.Columns.Add("Status");
                        dtSource.Columns.Add("Cancel");
                        ViewState["dtSource"] = dtSource;
                        gridItem.DataSource = dtSource;
                        gridItem.DataBind();
    
                }
            }
    
    
    protected void btnAdd(object sender, EventArgs e)
            {
                DataTable dtSource = ViewState["dtSource"] as DataTable;          
                DataRow dr = dtSource.NewRow();
                dtSource.Rows.Add(DateTime.Now, itemDetail, "", "");
                gridItem.DataSource = dtSource;
                gridItem.DataBind();
                ViewState["dtSource"] = dtSource;
            }
