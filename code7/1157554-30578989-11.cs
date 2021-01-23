    public class TabControlCustom : TabControl
    {
    	protected override System.Windows.DependencyObject GetContainerForItemOverride()
    	{
    		return new TabItemCustom();
    	}
    
    	protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    	{
    		base.OnSelectionChanged(e);
    
    		int i = 0;
    		foreach (var item in Items)
    		{
    			var tabItem = ItemContainerGenerator.ContainerFromItem(item) as TabItemCustom;
    			if (tabItem != null)
    			{
    				tabItem.IsItemAfterSelected = SelectedIndex >= i;
    			}
    			i++;
    		}
    	}
    }
