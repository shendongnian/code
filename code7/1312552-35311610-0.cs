    public class RequeryAllTheThings
    {
        private IViewModelManager _viewModelManager;
    
    	public RequeryAllTheThings(IViewModelManager viewModelManager)
    	{
    	    Argument.IsNotNull(() => viewModelManager);
    		
    		_viewModelManager = viewModelManager;
    		
    		System.Windows.Input.CommandManager.RequerySuggested += OnCommandManagerRequerySuggested;
    	}
    	
    	private void OnCommandManagerRequerySuggested(object sender, SomeEventArgs e)
    	{
    	    InvalidateCommands();
    	}
    	
    	private void InvalidateCommands()
    	{
    		var viewModels = _viewModelManager.ActiveViewModels;
    		foreach (var viewModel in viewModels)
    		{
    			var viewModelBase = viewModel as ViewModelBase;
    			if (viewModelBase != null)
    			{
    				var viewModelCommandManager = viewModelBase.GetViewModelCommandManager();
    				viewModelCommandManager.InvalidateCommands();
    			}
    		}
    	}
    }
