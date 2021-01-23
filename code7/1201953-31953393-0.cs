    private DispatcherTimer m_dispatcherTimer;
    public MainPage()
    {
            InitializeComponent();
            m_dispatcherTimer = new DispatcherTimer();
            m_dispatcherTimer.Interval = TimeSpan.FromTicks(10000);
            m_dispatcherTimer.Tick += frameworkDispatcherTimer_Tick;
            m_dispatcherTimer.Start();
            using (library = new MediaLibrary())
            {
              MediaPlayer.Play(library.Songs, 0);
            }
          
    }
    void frameworkDispatcherTimer_Tick(object sender, EventArgs e)
    {
        FrameworkDispatcher.Update();
    }
