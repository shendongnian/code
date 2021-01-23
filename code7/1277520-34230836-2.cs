    public partial class Window1 : System.Windows.Window
    {
    public Window1()
    {
      try
      {
        InitializeComponent();
      }
      catch ( Exception ex )
      {
      // Log error (including InnerExceptions!)
      // Handle exception
       MessageDialog dialog = new MessageDialog(ex.InnerException);
       dialog.ShowAsync();
      }
     }
    }
