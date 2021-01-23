    public class WellSchematic : UserControl
    {
    	public WellSchematic()
    	{
    		InitializeComponent();
    		
    		DataContext = this;
    		
    		ImagePaths.Add("Image1");
    		ImagePaths.Add("Image2");
    	}
    	
    	public ObservableCollection<string> ImagePaths {get;} = new ObservableCollection<string>();
    }
