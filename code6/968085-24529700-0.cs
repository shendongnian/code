    // ViewModel
    public class MainViewModel
    {
    	public event EventHandler<EventArgs<UpdateViewModel>> UpdateRequested;
    	
    	private void ExecuteUpdate()
    	{
    		if (this.UpdateRequested != null)
    		{
    			var childVm = new UpdateViewModel(/* parameters related to the object being updated */);
    			this.UpdateRequested(this, new EventArgs<UpdateViewModel>(childVm));
    		}
    	}
    }
    
    // View
    public class MainView
    {
    	public MainView()
    	{
    		var vm = new MainViewModel();
    		this.DataContext = vm;
    		
    		vm.UpdateRequested += (sender, e) =>
    		{
    			var updateView = new UpdateView();
    			updateView.DataContext = e.Data;	// Gets the instance of the viewModel here
    			
    			updateView.ShowDialog();
    		};
    	}
    }
