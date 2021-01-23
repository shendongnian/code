    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            var c1 = new Customer { ID = 1, Name = "Customer 1" };
            var c2 = new Customer { ID = 2, Name = "Customer 2" };
            lvCustomers.DataSource = new List<Customer> { c1, c2 };
            lvCustomers.DataBind();
        }
    }
    protected void btnDetails_Command(object sender, CommandEventArgs e)
    {
        if(e.CommandName == "ViewDetails")
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            //Do the database lookup using the ID...
            gvDetails.DataSource = new List<string> { "Customer Surname", "Customer Phone", "Customer Address" };
            gvDetails.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "showPopup();", true);
        }
    }
