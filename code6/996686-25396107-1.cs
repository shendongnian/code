    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Jon"},
                new Customer {Id = 2, Name = "Eric"}
            };
    
            rptQuery.DataSource = customers;
            rptQuery.DataBind();
        }
    }
    
    protected void rptQuery_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var customer = e.Item.DataItem as Customer;
            var button = e.Item.FindControl("Button1") as Button;
    
            button.CommandName = customer.Id.ToString();
            button.Text = customer.Name;
        }
    }
    
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandName);
        // Do something with id
    }
