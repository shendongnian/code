        public sealed partial class MainPage : BasePage
        {
            public ObservableCollection<ContactBook> Books;
    
            public MainPage()
            {
                this.InitializeComponent();
                // In Windows 8 apps you must set the DataContext. So uncomment the next line in that case
                //DataContext = this;
                Loaded += MainWindow_Loaded;
            }
    
            private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                Books = new ObservableCollection<ContactBook>();
                // add code to read from a service, database, etce
            }
    }
