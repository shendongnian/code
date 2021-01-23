    public DataTable MyDT;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MyDT = new DataTable();
            MyDT.Columns.Add("Name");
            MyDT.Columns.Add("Address");
            MyDT.Columns.Add("Email");
            MyDT.Columns.Add("Info");
            Session["MyDT"] = MyDT;
        }
        else
        {
            // Here we load the session datatable to the variable you declared at the top.
            // It will be ready for us in the button click event.  We know this because
            // of asp.net page lifecycle which will run the page_load before the button
            // click event.
            
            MyDT = (DataTable)Session["MyDT"];
        }
        // You can bind the repeater here also if you want.  Doesn't really make a huge difference
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Name = txtName.Text;
        string Address = txtAddress.Text;
        string Email = txtEmail.Text;
        string Info = txtInfo.Text;
        DataRow dtRow = MyDT.NewRow();
        dtRow["Name"] = Name;
        dtRow["Address"] = Address;
        dtRow["Email"] = Email;
        dtRow["Info"] = Info;
        MyDT.Rows.Add(dtRow);
        rptrData.DataSource = MyDT;
        rptrData.DataBind();
    }
