    public partial class Default2 : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
        var transfer = Page.PreviousPage as ITransferSomething;
        if (transfer != null && transfer.IsCrossPagePostBack) {
          SerializableValue = transfer.SerializableValue;
        }
      }
      public IList<vw_ServiceandProduct> SerializableValue {
        get { return (IList<vw_ServiceandProduct>)ViewState["SerializableValue"]; }
        set { ViewState["SerializableValue"] = value; }
      }
    }
