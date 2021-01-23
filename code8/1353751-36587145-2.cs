    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
            return;
        List<Row> Rows = new List<Row>();
        ViewState["Rows"] = Rows;
        BindGrid();
    }
    protected void BindGrid()
    {
        GridView1.DataSource = (List<Row>)ViewState["Rows"];
        GridView1.DataBind();
    }
    protected void Insert(object sender, EventArgs e)
        {
            List<Row> Rows = (List < Row >)ViewState["Rows"];
            Row r = new Row();
            r.FieldName = txtName.Text.Trim();
            r.FieldType = txtType.Text.Trim();
            Rows.Add(r);
            ViewState["Rows"] = Rows;
            BindGrid();
            txtName.Text = string.Empty;
            txtType.Text = string.Empty;
    }
