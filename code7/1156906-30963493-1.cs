    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable gdv1source = new DataTable();
            gdv1source.Columns.Add("ID");
    
            gdv1source.Rows.Add("1");
            GridView1.DataSource = gdv1source;
            GridView1.DataBind();
        }
    }
    
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        TextBox tb = (TextBox)row.FindControl("TextBoxDescription");
        string Text = tb.Text;
    
        lbltext.Text = "Text Value is: " + Text;
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gdv2 = (GridView)e.Row.FindControl("GridView2");
    
            BindGridView2(gdv2);
        }
    }
    
    private static void BindGridView2(GridView gdv2)
    {
        DataTable gdv2source = new DataTable();
        gdv2source.Columns.Add("UserDescription");
        gdv2source.Columns.Add("ReportId");
    
        gdv2source.Rows.Add("UserDescription1", "1");
        gdv2source.Rows.Add("UserDescription2", "2");
    
        gdv2.DataSource = gdv2source;
        gdv2.DataBind();
    } 
