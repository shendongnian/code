    public MainWindow()
    {
      InitializeComponent();
      Closing += MainWindow_Closing;
    }
    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      Properties.Settings.Default.Save();
    }
    private void OnlyNumberValidation(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^0-9]+");
      e.Handled = regex.IsMatch(e.Text);
    }
