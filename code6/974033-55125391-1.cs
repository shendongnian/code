    private void PropGrid_PreparePropertyItem(object sender, PropertyItemEventArgs e)
    {
    	var prop = e.Item as PropertyItem;
    	if (prop != null)
    	{
    		prop.IsExpandable = prop.PropertyType.IsClass;
    	}
    }
