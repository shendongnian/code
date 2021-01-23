    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
        BindGridView(this.txtSearch.Text);
    }
    }
    protected void BindGridView(string column1)
    {
    SqlCommand cmd = new SqlCommand("select * from table1 where (column1 like '%" + txtSearch.Text + "%')", con);
    con.Open();
    cmd.Parameters.AddWithValue("@column1 ", column1 );
    GridView1.DataSource = cmd.ExecuteReader();
    GridView1.DataBind();
    con.Close();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
    BindGridView(this.txtSearch.Text);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
    GridView1.EditIndex = e.NewEditIndex;
    BindGridView(this.txtSearch.Text);
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
    GridView1.EditIndex = -1;
    BindGridView(this.txtSearch.Text);
    }
