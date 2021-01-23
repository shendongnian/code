    public abstract class siteDynamic : System.Web.UI.Page
    {
        public string PageType { get; set; }
     protected override void OnPreInit(EventArgs e)
     {
         base.OnPreInit(e);
     }
    }
    public partial class siteler_page : siteDynamic
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected override void OnPreInit(EventArgs e)
    {
        base.PageType = "contentpage";
        base.OnPreInit(e);
    }
    }
