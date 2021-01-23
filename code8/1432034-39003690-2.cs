    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    	}
    
    	public object ViewModel
    	{
    		get { return (object)GetValue(ViewModelProperty); }
    		set { SetValue(ViewModelProperty, value); }
    	}
    	public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
    		"ViewModel",
    		typeof(object),
    		typeof(MainWindow));
    }
