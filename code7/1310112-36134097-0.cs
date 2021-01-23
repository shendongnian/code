    public class MainViewModel : ViewModelBase,IMainViewModel
    { 
    	/* Other piece of code */
         
    	private ViewModelBase _currentViewModel;
    
    	 public ViewModelBase CurrentViewModel
    	 {
    		 get
    		 {
    			 return _currentViewModel;
    		 }
    		 set
    		 {
    			 _currentViewModel = value;
    			 RaisePropertyChanged(() => CurrentViewModel);
    		 }
    	 }	
    }
