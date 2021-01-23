        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListView1.DataSource = new[] { 1, 2, 3, 4, 5 };
            this.ListView1.DataBind();
        }
        protected void Button1_Init(object sender, EventArgs e)
        {
            var dataList = ListView1.DataSource as IEnumerable<int>;
            var senderButton = (sender as Button);
            var data = (senderButton.NamingContainer as ListViewItem).DataItem;
            senderButton.Attributes.Add("data-x", data.ToString());
        }
