    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
     
            List<User> users = new List<User>();
            for (int i = 0; i < 10; ++i)
            {
                var user = new User { ID = i, Name = "Name " + i.ToString(), Age = 20 + i };
                if (i == 2 || i == 4)
                {
                    user.IsPremiumUser = true;
                }
                users.Add(user);
            }
            myListView.ItemsSource = users;
        }
    }
     
    public class PremiumUserDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            User user = item as User;
            if(user.IsPremiumUser)
            {
                return elemnt.FindResource("PremiumUserDataTemplate") as DataTemplate;
            }
            else
            {
                return elemnt.FindResource("NormalUserDataTemplate") as DataTemplate;
            }
        }
    }
     
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsPremiumUser { get; set; }
    }
