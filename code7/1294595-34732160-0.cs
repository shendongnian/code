	protected void Button1_Click(object sender, EventArgs e)
	{
		Label1.Text = DateTime.Now.ToLongTimeString();
		((Label)Parent.FindControl("UpdatePanel2").FindControl("Label2")).Text = DateTime.Now.ToLongTimeString();
		((UpdatePanel)Parent.FindControl("UpdatePanel2")).Update();
	}
