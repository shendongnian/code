    public class ConverterTabItemAriane : IMultiValueConverter
    {
    
    	public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		TabControl tabControl = values[0] as TabControl;
    		TabItem tabItem = values[1] as TabItem;
    		if (tabControl != null && tabItem != null && values[2] is int)
    		{
    			var selectedIndex = (int)values[2];
    			var itemIndex = tabControl.ItemContainerGenerator.IndexFromContainer(tabItem);
    			if (selectedIndex >= itemIndex)
    			{
    				return true;
    			}
    			else
    			{
    				return false;
    			}
    		}
    		return false;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
