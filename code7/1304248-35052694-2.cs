    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Test : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (Page.IsPostBack)
    		{
    			if (Request.Form["btn"] != null)
    			{
    				int btn = int.Parse(Request.Form["btn"]);
    
    				Response.Write(btn);
    			}
    		}
    	}
    }
