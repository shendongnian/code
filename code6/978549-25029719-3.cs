        public sealed partial class MainPage : Page
        {
        	public MainPage()
        	{
        		this.InitializeComponent();
        
        		this.Loaded += (sender, args) =>
        		{
        			this.Frame.Navigate(typeof(SecondPage));
        		};
        	}
        }
