    using Sitecore.Data.Items;
    using Sitecore.Web.UI.WebControls;
 
    public class BaseSublayout : System.Web.UI.UserControl {
 
    private Item _dataSource = null;
    public Item DataSource {
        get {
            if (_dataSource == null)
                if(Parent is Sublayout)
                    _dataSource = Sitecore.Context.Database.GetItem(((Sublayout)Parent).DataSource);
 
            return _dataSource;
        }
    }
 
    public BaseSublayout() : base() { }
 
    }
