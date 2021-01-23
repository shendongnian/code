    public partial class _Default : System.Web.UI.Page, ITransferSomething {
      protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
          SerializableValue = new List<vw_ServiceandProduct> {
            new vw_ServiceandProduct { Name = "foo" }
          };
        }
      }
      public IList<vw_ServiceandProduct> SerializableValue {
        get { return (IList<vw_ServiceandProduct>)ViewState["SerializableValue"]; }
        set { ViewState["SerializableValue"] = value; }
      }
    } 
