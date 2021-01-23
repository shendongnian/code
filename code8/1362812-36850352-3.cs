    using System;
    using System.Web.UI.WebControls;
    public partial class TestChildControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRemoveControl.CommandArgument = this.ID;
        }
        public Button RemoveControlButton
        {
            get { return btnRemoveControl; }
        }
    }
