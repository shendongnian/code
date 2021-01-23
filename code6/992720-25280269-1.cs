    public partial class MainWindow : Window
    {
        private bool mediaPlayerIsPlaying = false;
        public ObservableCollection<string> FileList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            GetFiles(@"E:\vids");
            this.DataContext = this;
        }
        private void GetFiles(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);
            FileList = new ObservableCollection<string>(files);
        }
        private void PlayPause(object sender, RoutedEventArgs e)
        {
            if (mediaPlayerIsPlaying)
            {
                musicDisplay.Pause();
                mediaPlayerIsPlaying = false;
            }
            else
            {
                musicDisplay.Play();
                mediaPlayerIsPlaying = true;
            }
        }
        private void Player_MediaEnded(object sender, EventArgs e)
        {
            int currentSongIndex = FileList.IndexOf(SelectedMedia);
            currentSongIndex++;
            if (currentSongIndex < FileList.Count)
            {
                SelectedMedia = FileList[currentSongIndex] as string;
                Play();
            }
            else
            {
                CurrentMedia = null;
            }
        }
        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            mediaPlayerIsPlaying = true;
        }
        void Play(string media = null)
        {
            musicDisplay.Stop();
            mediaPlayerIsPlaying = false;
            CurrentMedia = media ?? SelectedMedia;
            PlayPause(null, null);
        }
        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "All files (*.*) | *.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Play(open.FileName);
            }
        }
        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        public string CurrentMedia
        {
            get { return (string)GetValue(CurrentMediaProperty); }
            set { SetValue(CurrentMediaProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentMedia.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentMediaProperty =
            DependencyProperty.Register("CurrentMedia", typeof(string), typeof(MainWindow), new PropertyMetadata(null));
        public string SelectedMedia
        {
            get { return (string)GetValue(SelectedMediaProperty); }
            set { SetValue(SelectedMediaProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedMedia.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedMediaProperty =
            DependencyProperty.Register("SelectedMedia", typeof(string), typeof(MainWindow), new PropertyMetadata(null, (s, e) => (s as MainWindow).Play()));
    }
