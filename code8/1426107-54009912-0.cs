    private void Handler_ItemClick( object sender, RibbonControlEventArgs e )
	{
		try
		{
			String tag = GALLERY_FOR_THIS_SET_OF_ITEMS.SelectedItem.Tag;
			if (tag != null)
			{
				// use the tag to identify which "Item" it is. 
                // You also get access to other fields in the Item object
                // such as the name/id/label of the Item.
		    }
		}
		catch (Exception)
		{ }
	}
