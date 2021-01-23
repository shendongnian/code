    namespace WpfApplication7
    {
        class MainViewModel : ViewModelBase
        {
            private MainWindow mainWindow;
    
            private Visibility _isVisible = Visibility.Collapsed;
            public Visibility IsVisible
            {
                get
                {
                    return _isVisible;
                }
                set
                {
                    _isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
    
            public MainViewModel(MainWindow mainWindow)
            {
                this.mainWindow = mainWindow;
    
                mainWindow.boutontest.Click += BoutonClick;
            }
    
            private void BoutonClick(object sender, RoutedEventArgs e)
            {
                IsVisible = Visibility.Visible;
            }
        }
    }
