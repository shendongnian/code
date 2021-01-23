    public partial class MainPage : System.Web.UI.Page
    {
        private PageState _pageState;
        protected void Page_Load(object source, EventArgs e)
        {
            _pageState = ViewState["pageState"] as PageState ?? new PageState();
            _pageState.MyLabelPreviousText = MyLabel.Text;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["pageState"] = _pageState;
        }
