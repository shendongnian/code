        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = yourDataTableSource;
                GridView1.DataSource = dt;
                GridView1.PageSize = 10;
                GridView1.AllowPaging = true;
                GridView1.PagerSettings.Visible = false;
                GridView1.DataBind();
                ViewState["GridView1Content"] = dt;
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageSize = 10;
            //always do validation with user input...
            try
            {
                pageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            }
            catch
            {
            }
            GridView1.PageSize = pageSize;
            GridView1.DataSource = ViewState["GridView1Content"] as DataTable;
            GridView1.DataBind();
        }
