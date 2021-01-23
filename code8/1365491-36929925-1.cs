    public sealed partial class MainPage : Page
    {
        List<MachineData> Items = new List<MachineData>();
        public MainPage()
        {
            this.InitializeComponent();
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Application.Current.DebugSettings.EnableFrameRateCounter = false;
            }
            Items.Add(new MachineData());
            MyListBox.ItemsSource = Items;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (MachineData md in Items)
            {
                md.CurrentValue = "Update Text";
            }
        }
    }
