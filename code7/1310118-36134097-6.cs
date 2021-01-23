    public class MainViewModel : ViewModelBase,IMainViewModel
    {
    	public MainViewModel()
    	{
    		Messenger.Default.Register<ChangeView>(this, (action) => ReceiveMessage(action));
    		CurrentViewModel = HomeVM;
    	}
    		
    	private void ReceiveMessage(ChangeView viewName)
    	{
    		switch (viewName.switchView)
    		{
    			case ChangeView.EnumView.Home:
    				CurrentViewModel = HomeVM;
    				break;
    			case ChangeView.EnumView.Error:
    				CurrentViewModel = ErrorVM;
    				break;
                }
    		Messenger.Default.Unregister<ChangeView>(this, (action) => ReceiveMessage(action));
    	}
