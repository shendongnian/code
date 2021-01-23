    using System;
    namespace StackOverFlowWebForm
    {
        public partial class DemoForm : System.Web.UI.Page
        {
           protected string _content;
           protected void Page_Load(object sender, EventArgs e)
           {
              _content = "<h1>My Dynamic Title<h1>";
           }
        }
    }
