    public class MainViewModel : ViewModelBase,IMainViewModel
    {
    		public ViewModelBase HomeVM
    		{
    			get
    			{
    				return (ViewModelBase)ViewModelLocator.Home;
    			}
    		}
    }
