        public partial class MainWindow : Window {
        public static DependencyProperty dp_StatusBarText = DependencyProperty.Register("DP_StatusBarText", typeof (string), typeof (MainWindow));
        public string DP_StatusBarText
        {
            get { return (string) GetValue(dp_StatusBarText); }
            set { SetValue(dp_StatusBarText, value); }
        }
        public MainWindow() {
            InitializeComponent();
            tabControl.ItemsSource = new[] {
                new TestDataItem() {ID = 100, Text = "item1"},
                new TestDataItem() {ID = 200, Text = "item2"},
                new TestDataItem() {ID = 300, Text = "item3"}
            };
            tabControl.SetBinding(Selector.SelectedItemProperty, new Binding(nameof(SelectedItem)) {Source = this});
            DP_StatusBarText = "Main window loaded";
        }
        public TestDataItem SelectedItem
        {
            get { return (TestDataItem) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof (TestDataItem), typeof (MainWindow), new PropertyMetadata(null, OnSelectedItemChanged));
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((MainWindow) d).OnSelectedItemChanged();
        }
        private void OnSelectedItemChanged() {
            if (this.SelectedItem != null) {
                SetBinding(dp_StatusBarText, new Binding(nameof(SelectedItem.Text)) {Source = this.SelectedItem, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
            }
        }
    }
