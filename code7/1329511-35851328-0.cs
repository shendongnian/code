    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddMyTabItem();
        }
        private async void AddMyTabItem()
        {
            try
            {
                TabItem ti = new TabItem();
                ti.Header = "MyTableItemHeader";
                ti.Content = "MyTableItemContent";
                await AddTabItem(ti);
            }
            catch { }
        }
        private async Task AddTabItem(TabItem TI)
        {
            try
            {
                await TabControl1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate
                {
                    TabControl1.Items.Add(TI);
                });
            }
            catch { throw; }
         }
    }
