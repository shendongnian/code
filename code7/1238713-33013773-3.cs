        public class MenuItem
        {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        public string Title { get; set; }
        public ObservableCollection<MenuItem> Items { get; set; }
        }
        public partial class MainWindow : Window
        {
    
            private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                
                  MenuItem root = new MenuItem() { Title = "Menu" };
            MenuItem childItem1 = new MenuItem() { Title = "http://www.google.com" };
            childItem1.Items.Add(new MenuItem() { Title = "http://www.google.com" });
            childItem1.Items.Add(new MenuItem() { Title = "http://www.google.com" });
            root.Items.Add(childItem1);
            root.Items.Add(new MenuItem() { Title = "http://www.google.com" });
            trvMenu.Items.Add(root);
    
            }
        }
