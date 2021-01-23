    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = new List<Item>
            {
                new Item {Id = 1, Name = "John"},
                new Item {Id = 2, Name = "Eric"},
            };
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "wView")
        {
            var imageButton = e.CommandSource as ImageButton;
            string clientId = imageButton.ClientID;
            int id = Convert.ToInt32(e.CommandArgument);
        }
    }
