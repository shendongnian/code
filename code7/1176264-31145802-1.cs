    protected void Page_Load(object sender, EventArgs e)
    {
    CheckBoxList1.SelectedIndexChanged += new EventHandler(cbl_manual_clickEvent);
    DataTable dt3 = get_cbl_data(someparameter);
    CheckBoxList1.DataSource = dt3;
    CheckBoxList1.DataTextField = "Title";
    mycbl.DataValueField = "ID";
    CheckBoxList1.AutoPostBack = true;
    CheckBoxList1.DataBind();
    
    }
