     using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    
    namespace CodeprojectTest
    {
        public partial class WebForm1 : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var js = new HtmlGenericControl("script");
                js.Attributes["type"] = "text/javascript";
                js.Attributes["src"] = "JScript1.js";
                Page.Header.Controls.Add(js);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "Test();", true);
            }
        }
    }
