    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = new List<Customer>
        {
            new Customer {Id = 1, Name = "John"},
            new Customer {Id = 2, Name = "Marry"},
        };
        GridView1.DataBind();
    }
