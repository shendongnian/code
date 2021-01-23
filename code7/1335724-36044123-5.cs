    public class Menu : ObservableCollection<DeHavMenu>
    {
    	public double TotalPrice 
    	{
    		get 
    		{ 
    			var totalPrice = 0.0;
    			foreach (var menuItem in this)
    			{
    				if (menuItem.IsSelected)
    				{
    					totalPrice += menuItem.Price;
    				}
    			}
    			return totalPrice;
    		}
    	}
    }
