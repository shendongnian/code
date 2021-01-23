    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    	    InitializeComponent();
    	}
    
    	private void Window_KeyDown(object sender, KeyEventArgs e)
    	{
    	    // ... Test for F5 key.
    	    if (e.Key == Key.F5)
    	    {
    		this.Title = "You pressed F5";
    	    }
    	}
    }
