    public abstract class siteDynamic : System.Web.UI.Page
    {
         public siteDynamic()
         {
            // ...
         }
         public abstract string PageType { get; }
         protected override void OnPreInit(EventArgs e)
         {
               string type = this.PageType;
               // ...
               base.OnPreInit(e);
         }
    }
    public partial class siteler_page : siteDynamic
    {
         public override string PageType
         {
              get
              {
                   return "contentpage";
              }
         }
         protected void Page_Load(object sender, EventArgs e)
         {
              // ...
         }
    }
