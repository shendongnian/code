    protected void buttSubmit_Click(object sender, EventArgs e)
    {
		ContentPlaceHolder parentCP = this.Master.Master.FindControl("MainContent") as ContentPlaceHolder;
		ContentPlaceHolder childCP = parentCP.FindControl("NestedMainContent") as ContentPlaceHolder;
		string strTextbox = string.Empty;                
		
		for (int i = 1; i < 6; i++)
		{
		   strTextbox = "ArticleNr" + i.ToString();
		   TextBox txt = childCP.FindControl(strTextbox) as TextBox;
		   if (txt != null && !string.IsNullOrEmpty(txt.Text))
		   {
			  // ... 
			  // Insert to db
			  // ...
		   }
		}
	}
