    public sealed partial class MainView : Page
    {
        private static readonly IList<sqlitetable> data = null;
        public IList<sqlitetable> Data
        {
            get
            {
                if (data == null)
                {
                    data = new List<sqlitetable>();
                    // Populates the Collection
                    using (var db = new SQLiteConnection(new SQLitePlatformWinRT(), Path.Combine(Package.Current.InstalledLocation.Path, "Assets", "database.db")))
                    {
                        foreach (var entry in db.Table<sqlitetable>())
                        {
                            data.Add(new sqlitetable { Image = "/Assets/pics/" + entry.ID + ".png", Name = entry.Name, Type1 = "/Assets/Types/" + entry.Type1 + ".png", Type2 = "/Assets/Types/" + entry.Type2 + ".png", dummyID = "# " + entry.ID.ToString("000") });
                        }
                    }
                }
                return data;
            }
        }
        public MainView()
        {
            this.InitializeComponent();
            gridView.ItemsSource = Data;
        }
    }
