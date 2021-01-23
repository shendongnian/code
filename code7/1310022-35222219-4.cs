    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string MeaningfulNameForLabelText
        {
            get { return this.UserControl1.MeaningfulNameForLabelText; }
            set { this.UserControl1.MeaningfulNameForLabelText = value; }
        } 
    }
