    public partial class RepeaterExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                var c1 = new ContextMenu { Title = "Context Menu 1", Items = "Menu1|Menu1|Menu1" };
                var c2 = new ContextMenu { Title = "Context Menu 2", Items = "Menu2|Menu2|Menu2" };
                rptMenu.DataSource = new List<ContextMenu> { c1, c2 };
                rptMenu.DataBind();
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ContextMenu item = e.Item.DataItem as ContextMenu;
            Label lblTitle = (Label)e.Item.FindControl("lblTitle");
            lblTitle.Text = item.Title;
            GridView gvItems = (GridView)e.Item.FindControl("gvItems");
            gvItems.DataSource = item.Items.Split('|');
            gvItems.DataBind();
        }
    }
    public class ContextMenu
    {
        public string Title { get; set; }
        public string Items { get; set; }
    }
