    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication2
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			System.Windows.Controls.WebBrowser browser = new System.Windows.Controls.WebBrowser();
                // you can put any other uri here, or better make browser field and navigate to desired uri on some event
    			browser.Navigate(new Uri("http://www.blic.rs/")); 
    			grdBrowserHost.Children.Add(browser);
    		}
    
    		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    		{
    			if (e.Key == Key.Escape)
    			{
    				this.Close();
    			}
    			else
    			{
    				this.Topmost = !this.Topmost;
    			}
    		}
    	}
    }
