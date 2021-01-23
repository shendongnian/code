    public partial class MainWindow : Window
    {
        Timer timer2 = new Timer(3000);
        Timer timer = new Timer(100);
        Dispatcher gui = Dispatcher.CurrentDispatcher;
        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<Item>();
            this.DataContext = this;
            timer.Elapsed += (s, e) =>
            {
                gui.Invoke(() => new Action(() =>
                    {
                        foreach (Item item in Items)
                        {
                            if (item.Value < item.Maximum)
                            {
                                item.Value++;
                            }
                        }
                    }).Invoke());
            };
            timer.Enabled = true;
            Random rand = new Random();
            timer2.Elapsed += (s, e) =>
                {
                    gui.Invoke(() =>                         
                    Items.Add(new Item()
                    {
                        Minimum = rand.Next(1, 30),
                        Maximum = rand.Next(35, 100),
                    }));
                };
            timer2.Enabled = true;
        }
        public ObservableCollection<Item> Items
        {
            get;
            private set;
        }
    }
