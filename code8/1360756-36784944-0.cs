        public partial class MainWindow : Window
        {
            public ObservableCollection<User> items = new ObservableCollection<User>();
        
            public MainWindow()
            {
                InitializeComponent();
                listViewUsers.ItemsSource = items;
                
            }
           
             someEventHandler
               {
                    items.Add(new User() { Name = "John", Age = 42 });
                    
               }
    }
