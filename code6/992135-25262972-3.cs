    public MainPage()
    {
        InitializeComponent();
        loadData();
    }
    public void loadData()
    {
        List<DB> list = new List<DB>();
        list.Add(new DB(1, "Item1", true, "10"));
        list.Add(new DB(2, "Item2", false, "20"));
        list.Add(new DB(3, "Item3", true, "30"));
        list.Add(new DB(4, "Item4", false, "40"));
        list.Add(new DB(5, "Item5", true, "50"));
        LstDB.ItemsSource = list;
    }
    public class DB
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public bool isActivated { get; set; }
        public string value { get; set; }
        public DB()
        { }
        public DB(int id, string itemName, bool isActivated, string value)
        {
            this.id = id;
            this.itemName = itemName;
            this.isActivated = isActivated;
            this.value = value;
        }
    }
