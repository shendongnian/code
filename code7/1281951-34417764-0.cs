    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var context = new CustomersContext())
            {
                customer = context.Logins.First();
            }
            CustomerDetailsView.DataSource = new List<Customer>() { customer };
            CustomerDetailsView.DataBind();
        }
    }
