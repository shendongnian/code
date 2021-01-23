    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string MeaningfulNameForLabelText
        {
            get { return this.lbl1.Text; }
            set { this.lbl1.Text = value; }
        } 
    }
