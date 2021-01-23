        class AppViewModel : BaseViewModel 
        {
            static AppViewModel() 
            {
                _AppModel = new AppViewModel();
    	    }
    	    private static AppViewModel _AppModel;
    
    	    public static AppViewModel Current 
            {
    		    get { return _AppModel;  }
    	    }
    
    	    private AppViewModel()
    	    {
    	    	//Initialize view models here
    	    	MainPageModel = new MainPageViewModel();
        	}
    
    	    //VIEW MODELS
    
    	    public MainPageViewModel MainPageModel { get; private set; }
        }
