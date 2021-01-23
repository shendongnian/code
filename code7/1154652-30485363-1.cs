    using System;
    using System.Web.UI;
    
    public class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("LOAD");
            Response.End();
        }
    }
