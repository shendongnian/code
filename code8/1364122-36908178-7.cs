    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        // Changes these to your field names
        cmbEmp_Name.DataTextField= "Name";
		cmbEmp_Name.DataValueField = "DoctorID";
        // This code populate the CheckBoxList in my own project
        // Your Post doesn't show how you populate your control
        // I assume it's being done elsewhere in your code.
        // But it is important to understand that if you do not load
        // the CheckBoxList within a `if (!Page.IsPostBack)` block anything
        // you select in the list will be lost when you click the button
        // because the control will be repopulated on Postback.
		cmbEmp_Name.DataSource = ef6Context.GetListOfNames().ToList();
		cmbEmp_Name.DataBind();      
      }
    }
    //Button1 Postback bind the Gridview.
    protected void Button1_Click(object sender, EventArgs e)
    {
      // Once you select a number of items from `cmbEmp_Name` and hit your
      // button this statement will create and Array of `ListItem`s
      grdMonthlyProc.DataSource = cmbEmp_Name.Items
                                      .Cast<ListItem>()
                                      .Where(li => li.Selected)
                                      .ToArray();
      // And this will Bind the Array to the GridView.  Internally GridView 
      // will extract all Public Properties of a ListItem and automatically
      // generate a default set of Columns to display.  With a simple
      // redefinition you can display specific columns, but more on that later
      grdMonthlyProc.DataBind();
    }
