	protected void MailRepeater_DataBinding(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
			var lbl = (Label)e.Item.FindControl("lblFlagged");
			lbl.Text = "Hello world";
		}
	}
