    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        // Changes these to your field names
        cmbEmp_Name.DataTextField= "Name";
		cmbEmp_Name.DataValueField = "DoctorID";
        // Replace Datasource assignment with your functionality
		cmbEmp_Name.DataSource = ef6Context.GetListOfNames().ToList();
		cmbEmp_Name.DataBind();      
      }
    }
    //Button1 Postback bind the Gridview.
    protected void Button1_Click(object sender, EventArgs e)
    {
      GridView2.DataSource = ListBox1.Items
                               .Cast<ListItem>()
                               .Where(li => li.Selected == true)
                               .ToArray();
      GridView2.DataBind();
    }
