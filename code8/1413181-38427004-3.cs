    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Episodes> episodes = new List<Episodes>();
            for (int i = 0; i < 10; i++)
            {
                episodes.Add(new Episodes()
                {
                    Season = i.ToString(),
                    Episode = (i + 2).ToString(),
                    Download = true,
                    Watched = true,
                });
            }
            EpisodesList.ItemsSource = episodes;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Episodes epi = chk.DataContext as Episodes;
            var season = epi.Season;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Episodes epi = chk.DataContext as Episodes;
            var season = epi.Season;
        }
    }
