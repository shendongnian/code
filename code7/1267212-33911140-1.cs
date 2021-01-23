    public MainWindow()
    {
       InitializeComponent();    
       PaintProgressBar();
    }
    private void PaintProgressBar()
    {            
       ProgressBar progressBar = new ProgressBar();
       progressBar.IsIndeterminate = true;
       progressBar.Margin = new Thickness(10, 0, 10, 10);
       progressBar.Visibility = Visibility.Visible;
       progressBar.Height = 25;
       //progressBar.FlowDirection = FlowDirection.LeftToRight;
       progressBar.Foreground = System.Windows.Media.Brushes.Green;
       progressBar.Background = System.Windows.Media.Brushes.Red;
       progressBar.Value = 50;
       stackPanel.Children.Add(progressBar);
    }
