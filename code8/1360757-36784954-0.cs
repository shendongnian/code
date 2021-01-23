    public partial class MainWindow : Window
    {
        public ObservableCollection<User> items = new ObservableCollection<User>();
    
        someEventHandler
        {
             items.Add(new User() { Name = "John", Age = 42 });
            
        }
    }
