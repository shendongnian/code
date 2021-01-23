        private ListItem CreateListItem(string value, string text, string dataImage) {
            ListItem li = new ListItem() { Value = value, Text = text };
            li.Attributes["data-image"] = dataImage;
            return li;
        }
        protected void Page_Load(object sender, EventArgs e) {
            List<ListItem> lis = new List<ListItem>();
            lis.Add(CreateListItem("test1", "blah1", "test.png"));
            lis.Add(CreateListItem("test2", "blah2", "test2.png"));
            lis.Add(CreateListItem("test3", "blah3", "test3.png"));
            if (!IsPostBack) {
                foreach (ListItem li in lis)
                    webmenu.Items.Add(li);
            }
            else { 
                // persist custom attributes 
                for (int i = 0; i < webmenu.Items.Count; i++)
                    webmenu.Items[i].Attributes["data-image"] = lis[i].Attributes["data-image"];
            }
        }
