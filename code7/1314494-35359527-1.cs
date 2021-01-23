    public class Item
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var data = Enumerable.Range(1, 6)
                .Select(x => new Item() { Index = x, 
                                          Text = "Item " + x.ToString(), 
                                          Checked = (x % 2) == 0 });
            rpt.DataSource = data;
            rpt.DataBind();
        }
    }
