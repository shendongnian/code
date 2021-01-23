    public partial class Window1 
        {
            private object _lock = new object();
            public Window1()
            {
                InitializeComponent();
                BindingOperations.EnableCollectionSynchronization(this.Files, this._lock);
    
                this.DataContext = this;
            }
    
            public ObservableCollection<string> Files => this._files;
    
            private ObservableCollection<string> _files = new ObservableCollection<string>();
    
            private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                await Task.Run(() =>
                {
                    foreach (var file in Directory.GetFiles(yourPath)
                    {
                        this.Files.Add(file);
                    }
                });
            }
        }
