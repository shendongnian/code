       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();//data binding for dropdownlist
                //BindRegionWiseTally();//data binding for gridview
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("Invoked sucessfully.");
        }
        protected void BindDropDown()
        {
            DropDownList1.Items.Add("All");
            DropDownList1.Items.Add("New");
            DropDownList1.Items.Add("Update");
            DropDownList1.Items.Add("Delete");
        }
