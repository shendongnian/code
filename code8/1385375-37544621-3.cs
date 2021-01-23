    public partial class MainWindow : Window
    {
      // -- DECLARE focus HERE
      private Ford focus;
      public MainWindow()
      {
        InitializeComponent();
        // --- focus can be CREATED HERE --- 
        this.focus = new Ford();
      }
      private void button_Click(object sender, RoutedEventArgs e)
      {
        // -- Now you can USE focus HERE --
        this.focus.Color = "Sky blue";
      }
    }
