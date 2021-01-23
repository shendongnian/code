	public sealed partial class BlankPage1 : Page
    {
        public User CurrentUser
        {
            get { return (User)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(User), typeof(BlankPage1), new PropertyMetadata(null));
        public BlankPage1()
        {
            this.InitializeComponent();
            CurrentUser = new User() { Name = "Hello", Age = "20" };
        }
    }
    public class User
    {
        public String Name { get; set; }
        public String Age { get; set; }
    }
