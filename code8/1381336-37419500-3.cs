    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                DataRow dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Sharique";
                dr[2] = "120";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Ansari";
                dr[2] = "100";
                dt.Rows.Add(dr);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
            
            
        }
