    using System;
    using System.Data;
    using System.Configuration;
    
    public partial class _Default : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
            string email = Request.QueryString["email"] ?? "null";
    		if (email != "null") {
