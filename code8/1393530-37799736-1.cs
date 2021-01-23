        namespace DataContext_Learning
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new Register();
            }
        }
    
        class Register
        {
            public User NewUser { get; set; }
            public ObservableCollection<string> States { get; set; }
            public Register()
            {
                NewUser = new User();
                States = new ObservableCollection<string> { "CH", "MA", "KL", "FL" };
            }
        }
    
    
        public class User
        {
            public int UserId { get; set; }
    
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string State { get; set; }
        }
    }
