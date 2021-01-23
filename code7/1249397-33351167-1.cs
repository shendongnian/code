    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Data
            {
                Items = new List<string>
                {
                    "item 1",
                     "item 2",
                      "item 3",
                       "item 4",
                        "item 5",
                         "item 6",
                          "item 7",
                }
            };
        }
    }
    
    public class Data
    {
        public List<string> Items { get; set; } 
    }
