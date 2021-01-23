    public class YourView 
    {
    	prvate FormEvents instance = new FormEvents();
    	
    	public YourView()
    	{
    		instance.SomeName.PropertyChanged += EventHandler;
    		
    	}
    	
    	private void EventHandler(object obj)
    	{
    		TextBoxinYourView.Text = instance.SomeName;
    	}
    }
 
