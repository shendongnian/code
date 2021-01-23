    public interface IWinOwnerCollection
        {
            List<Window> WinOwnerCollection { get; }
        }
    
    class MainWindow : Window, IWinOwnerCollection
        {
            public List<Window> WinOwnerCollection { get; private set; }
    
            Task newWindowTask;
    
            public MainWindow()
            {
                InitializeComponent();
                WinOwnerCollection = new List<Window>();
                this.Closed += (sender, args) =>
                {
                    newWindowTask = null;
                };
            }
    
            private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                try
                {
    
                    if (newWindowTask == null)
                    {
                        newWindowTask = new Task(() =>
                        {
                            Dispatcher.Invoke(() =>
                            {
                                var wpfwindow = new Window1();
                                wpfwindow.WinOwner = this;
                                wpfwindow.Show();
    
                                wpfwindow.WinOwner.Closed += (o, args) =>
                                {
                                    wpfwindow.Close();
                                    //newWindowTask.Abort();
                                };
                            }, DispatcherPriority.Render);
                        });
                        newWindowTask.Start();
                    }
                    else if (newWindowTask.Status == TaskStatus.RanToCompletion)
                    {
                        foreach (var window in WinOwnerCollection)
                        {
                            window.Activate();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
    
    
        }
