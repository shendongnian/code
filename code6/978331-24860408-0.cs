        public partial class MainWindow : Window
        {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var g in listBox.Items)
            {
                if (g is Grid)
                {
                    foreach (var c in (g as Grid).Children)
                    {
                        if (c is TextBlock)
                            (c as TextBlock).MouseDown += TextBlock_Click;
                    }
                }
            }
        }
        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSelected != null)
                CurrentSelected.Foreground = new SolidColorBrush(Colors.Black); // here you can set foreground default color
            (CurrentSelected = (sender as TextBlock)).Foreground = new SolidColorBrush(Colors.Red); // here you can set foreground after change
        }
        private TextBlock CurrentSelected
        {
            get;
            set;
        }
    }
