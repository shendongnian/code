    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            R0.Visibility = Visibility.Visible;
            R1.Visibility = Visibility.Collapsed;
            R2.Visibility = Visibility.Collapsed;
            R3.Visibility = Visibility.Collapsed;
        }
        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as Grid;
            string tag = grid.Tag as string;
            // do more stuff depending on tag
            switch (int.Parse(tag))
            {
                case 0:
                    R0.Visibility = Visibility;
                    R1.Visibility = Visibility.Collapsed;
                    R2.Visibility = Visibility.Collapsed;
                    R3.Visibility = Visibility.Collapsed;
                    MyList.DataContext = null;  // todo: SET TO YOUR DATA MODEL
                    break;
                case 1:
                    R1.Visibility = Visibility;
                    R0.Visibility = Visibility.Collapsed;
                    R2.Visibility = Visibility.Collapsed;
                    R3.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
