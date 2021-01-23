    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataSource = objLogic.LoadClient();
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "clientId";
            DropDownList1.DataBind();
            BindGrid();
        }
     }
    protected void BindGrid()
    {
        GridView1.DataSource = objLogic.LoadContacts(Convert.ToInt16(DropDownList1.SelectedValue));
        GridView1.DataBind();
    }
        
