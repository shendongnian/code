	protected void shoppingcartlines_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		RepeaterItem item = e.Item;
		HtmlTableCell td = (HtmlTableCell)item.FindControl("idOfTdYouWantToHide");
		if (iWantToDisplay)
		{
			td.Visible = true;
			// if that doesn't work, just do:
			//	  td.Style.Add("display", "none");
		}
	}
