     public class BaseUserControl : System.Web.UI.UserControl
     {
        public Item Item { get; private set; }
        public NameValueCollection Parameters { get; private set; }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Parameters = WebUtil.ParseUrlParameters(Attributes["sc_parameters"]);
            var datasource = Attributes["sc_datasource"];
            Item = Sitecore.Context.Item;
            if (!string.IsNullOrEmpty(datasource))
            {
                var datasourceItem = Sitecore.Context.Database.GetItem(datasource);
                if(datasource != null)
                {
                    Item = datasourceItem;
                }
            }
        }
    }
