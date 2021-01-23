    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
        // --- focus is declared HERE --- 
        Ford focus = new Ford();
      }
      private void button_Click(object sender, RoutedEventArgs e)
      {
        // -- Your try to use focus HERE --
        focus.Color = "Sky blue";
      }
    }
