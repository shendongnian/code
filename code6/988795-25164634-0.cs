    public class App : Application
    {
    	protected override void OnStartup(StartupEventArgs e)
    	{
    		// Make sure you remove the StartupUri in App.xaml.
    		this.MainWindow = new Window("parameter-value");
    		this.MainWindow.Show( );
    		base.OnStartup(e);
    	}
    }
   
