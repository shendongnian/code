    namespace Project.COMMON
    {
        public partial class Page: BasePage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                this.txbTest.Text = "Hello";
            }
        }
        public partial class Page{
            protected global::System.Web.UI.WebControls.TextBox txbTest;                
        }
    }
