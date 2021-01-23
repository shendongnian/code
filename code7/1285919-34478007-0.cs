    public List<string> MyItems { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MyItems = new List<string>();
            MyItems.Add("Item 1");
            MyItems.Add("Item 2");
            MyItems.Add("Item 3");
            MyItems.Add("Item 4");
        }
