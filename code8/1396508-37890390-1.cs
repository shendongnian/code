    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
    		BindGrid();
    	}
    }
    
    private void BindGrid()
    {
    	DataTable dt;
    
    	if (Session["dt"] != null) // Submit
    	{
    		dt = Session["dt"] as DataTable;
    	}
    	else // !IsPostBack
    	{
    		dt = GetSampleData();
    	}
    
    	gv1.DataSource = dt;
    	gv1.DataBind();
    
    	GenerateTextBoxes(dt);
    
    	Session["dt"] = dt;
    }
    
    protected void Submit_Click(object sender, EventArgs e)
    {
    	string[] keyValue;
    
    	var dt = Session["dt"] as DataTable;
    	var dr = dt.NewRow();
    	var data = hdn1.Value; // JS set this as "Column1:value1~Column2:value12"
    	var pairs = data.Split('~');
    
    	foreach (var pair in pairs)
    	{ 
    		keyValue = pair.Split(':');
    		dr[keyValue[0]] = keyValue[1];
    	}
    
    	dt.Rows.Add(dr);
    	hdn1.Value = null;
    	Session["dt"] = dt;
    	BindGrid();
    }
    
    private void GenerateTextBoxes(DataTable dt)
    {
    	foreach (DataColumn col in dt.Columns)
    	{
    		pn1.Controls.Add(new TextBox { ID = col.ColumnName });
    	}
    }
    
    private DataTable GetSampleData()
    {
    	var dt = new DataTable();
    	dt.Columns.Add("Column1", typeof(string));
    	dt.Columns.Add("Column2", typeof(string));
    
    	var dr = dt.NewRow();
    	dr["Column1"] = "Think 2ce";
    	dr["Column2"] = "Code 1ce";
    
    	dt.Rows.Add(dr);
    
    	return dt;
    }
