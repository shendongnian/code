    namespace Project.A
    {
        public partial class Page: BasePage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                this.txbTest.Text = "Hello";
            }
        }
    }
