    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    
    namespace TestWeb
    {
        public partial class TestWebUserControl : UserControl
        {
            public HtmlInputGenericControl InnerControlEmail
            {
                get { return ControlEmail; }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                var x = ControlEmail.Value;
            }
        }
    }
