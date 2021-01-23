    using System;
    using System.Web.UI;
    
    namespace TestWeb
    {
        public partial class TestWebForm : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var y = TestWebUser.InnerControlEmail.Value;
            }
        }
    }
