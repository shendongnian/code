    public partial class MediaWindow : Window
    {
        public MediaWindow()
        {
            InitializeComponent();
            video.Source = new Uri(@"C:\video\test.asf");
            Play();
        }
        public void Play()
        {
            video.Play();
        }
    }
