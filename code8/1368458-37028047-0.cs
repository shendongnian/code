    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Country> items = new List<Country>();
            items.Add(new Country() { Name = "Italy", League = new League { Name = "Serie A" } }); // Added "new League"
            items.Add(new Country() { Name = "Italy", League = new League { Name = "Serie B" } });
            items.Add(new Country() { Name = "England", League = new League { Name = "Premiere League" } });
            items.Add(new Country() { Name = "Spain", League = new League { Name = "Primeira Division" } });
            lvUsers.ItemsSource = items;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupNations = new PropertyGroupDescription("Name");
            view.GroupDescriptions.Add(groupNations);
            PropertyGroupDescription groupCompetions = new PropertyGroupDescription("League.Name"); // Changed "League" to "League.Name"
            view.GroupDescriptions.Add(groupCompetions); // Fixed the variable name here
            lvUsers.ItemsSource = view; // Added, you probably have it but didn't post it
        }
    }
    public struct League
    {
        public string Name { get; set; }
    }
    public struct Country
    {
        public string Name { get; set; }
        public League League { get; set; } // added getter and setter
    }
