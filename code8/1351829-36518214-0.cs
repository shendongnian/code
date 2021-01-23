        public partial class YourPage: System.Web.UI.Page
        {
            private PageState _pageState;
            protected void Page_Load(object source, EventArgs e)
            {
                _pageState = ViewState["pageState"] as PageState ?? new PageState();
            }
            protected void Page_PreRender(object sender, EventArgs e)
            {
                ViewState["pageState"] = _pageState;
            }
        }
        [Serializable]
        public class PageState
        {
            //Whatever data you need to persist
        }
