        public sealed partial class MainPage : Page
        {
        	public MainPage()
        	{
        		this.InitializeComponent();
        	}
        
        	protected override void OnNavigatedTo(NavigationEventArgs e)
        	{
        		base.OnNavigatedTo(e);
        
        		this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        		{
        			this.Frame.Navigate(typeof(SecondPage));
        		});
        	}
        }
