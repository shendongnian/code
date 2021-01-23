    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {		
    		public MainPageViewModel MainPageVM = new MainPageViewModel();
    		public SecondPageViewModel SecondPageVM = new SecondPageViewModel();
    
    		public ShellViewModel()
    		{			
    			LoadMainPage();	// auto load main page on startup
    		}
    
    		public void LoadMainPage()
    		{
    			ActivateItem(MainPageVM);
    		}
    
    		public void LoadSecondPage()
    		{
    			ActivateItem(SecondPageVM);
    		}
    }
