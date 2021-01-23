    [Serializable()]
    public class MyValues
    {
        public string Value1 {get;set;}
        public string Value2 {get;set;}
    }
    public partial class YourPage: System.Web.UI.Page
    {
        private MyValues _values;
        protected void Page_Load(object source, EventArgs e)
        {
            _values = ViewState["myValues"] as MyValues ?? new MyValues ();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["myValues"] = _values;
        }
    }
