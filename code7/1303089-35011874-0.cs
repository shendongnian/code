    public sealed partial class MainPage : Page
    {
    	private IViewModel ViewModel => DataContext as IViewModel;
    
    	public MainPage()
    	{
    		this.InitializeComponent();
    	}
    
    	protected override void OnNavigatedTo(NavigationEventArgs e)
    	{
    		base.OnNavigatedTo(e);
    		UpdateVisualState(VisualStateGroup.CurrentState);
    	}
    
    	private void UpdateVisualState(VisualState currentState)
    	{
    		ViewModel.CurrentState = currentState;
    	}
    
    	private void OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
    	{
    		UpdateVisualState(e.NewState);
    	}
    }
