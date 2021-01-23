    public partial class MainWindow : Window
    {
        Db_Context db = null;
        public MainWindow()
        { db = new Db_Context(); }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            await db.Users.LoadAsync();
            
            /* Data usage */
            
            /* Binding */
            CollectionViewSource userViewSource = ((CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.Source = db.Users.Local;
            /* Add data */
            db.Users.Add(new User());
            await db.SaveChangesAsync();
            this.list_Users.Items.Refresh();
            
        } 
    }
    public class Db_Context : DbContext
    {
        public Db_Context() : base("DataBaseName") { }
        public DbSet<User> Users { get; set; }
    }
