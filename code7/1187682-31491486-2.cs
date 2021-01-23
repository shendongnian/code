        public partial class MainView : UserControl
	    {
		    public MainView()
		    {
		    	InitializeComponent();
                //Prevent view updating in Designer
		    	if (DesignerProperties.GetIsInDesignMode(this))
		    	{
		    		return;
		    	}
		    	var mainVM = AppViewModel.Current.MainPageModel;
	    		DataContext = mainVM;
            }
        }
