    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string MenaingfulNameForLabelText 
        {
            get { return this.UserControl1.MenaingfulNameForLabelText; }
            set { this.UserControl1.MenaingfulNameForLabelText = value; }
        } 
    }
