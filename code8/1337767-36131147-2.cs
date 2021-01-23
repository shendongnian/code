    public class CustomPage : ContentPage
    {
    	private Button btn {get;set;}
    
    	public CustomPage()
    	{
    		if(btn == null)
    			btn = createButtonFunction();
    		btn.SetBinding<ViewModelClassName>(Button.CommandProperty, vm => vm.CommandFromViewModel)
            //btn.SetBinding(Button.CommandProperty, "CommandFromViewModel")//other way to set binding
    	}
    	
    }
