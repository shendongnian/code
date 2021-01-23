	// In base class
	protected void LoadJavaScript(System.Web.UI.Page page)
	{
		string key = "MyJavaScript";
		if (page.ClientScript.IsStartupScriptRegistered(key))
		{
			StringBuilder sb = new StringBuilder();
			
			sb.AppendLine("alert('hello');");
			
			page.ClientScript.RegisterStartupScript(page.GetType(), 
				key, sb.ToString(), true);
		}
	}
	// In subclass
	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadJavaScript(this.Page);
	}
