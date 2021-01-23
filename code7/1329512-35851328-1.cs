    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // this simulates some User event, e.g. Button click
            AddMyTabItem();
        }
        // in real-life app this could be replaced w/event handler
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
        // implements async/await asynchronous for responsive UI
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
