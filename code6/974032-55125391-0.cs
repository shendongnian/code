    private void PropGrid_SelectedObjectChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
    {
    	var grid = sender as PropertyGrid;
    	foreach (PropertyItem prop in grid.Properties)
    	{
    		prop.IsExpandable = prop.PropertyType.IsClass;
    	}
    }
