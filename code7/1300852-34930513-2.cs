    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            return;
        }
        DataTable environments = new DataTable();
        var connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    
        using (SqlConnection conn = new SqlConnection(connection))
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Environment FROM Environments", conn);
            adapter.Fill(environments);
            ddlEnvironment.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlEnvironment.SelectedIndex = 0;
            ddlEnvironment.DataSource = environments;
            ddlEnvironment.DataTextField = "Environment";
            ddlEnvironment.DataValueField = "Environment";
            ddlEnvironment.DataBind();
        }
    }
