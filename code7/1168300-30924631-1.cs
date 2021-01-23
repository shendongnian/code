    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Init(object source, System.EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindToIEnumerable(RadTreeView1);
        }
        internal class SiteDataItem
        {
            private string text;
            private int id;
            private int parentId;
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public int ParentID
            {
                get { return parentId; }
                set { parentId = value; }
            }
            public SiteDataItem(int id, int parentId, string text)
            {
                this.id = id;
                this.parentId = parentId;
                this.text = text;
            }
        }
        private static void BindToIEnumerable(RadTreeView treeView)
        {
            List<SiteDataItem> siteData = new List<SiteDataItem>();
            siteData.Add(new SiteDataItem(1, 0, "Products"));
            siteData.Add(new SiteDataItem(2, 1, "Telerik UI for ASP.NET Ajax"));
            siteData.Add(new SiteDataItem(3, 1, "Telerik UI for Silverlight"));
            siteData.Add(new SiteDataItem(4, 2, "RadGrid"));
            siteData.Add(new SiteDataItem(5, 2, "RadScheduler"));
            siteData.Add(new SiteDataItem(6, 2, "RadEditor"));
            siteData.Add(new SiteDataItem(7, 3, "RadGrid"));
            siteData.Add(new SiteDataItem(8, 3, "RadMenu"));
            siteData.Add(new SiteDataItem(9, 3, "RadEditor"));
            siteData.Add(new SiteDataItem(10, 9, "RadEditor1"));
            siteData.Add(new SiteDataItem(11, 9, "RadEditor1"));
            treeView.DataTextField = "Text";
            treeView.DataFieldID = "ID";
            treeView.DataFieldParentID = "ParentID";
            treeView.DataSource = siteData;
            treeView.DataBind();
        }
    }
