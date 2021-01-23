    public static Calendar Calendar;
    CalenderBackground background = new CalenderBackground(Calendar);
    Fixtures fixtures;
    
    public MainWindow()
    {
         InitializeComponent();
         AppWindow = this;
         fixtures = new Fixtures(background);
    }
    class Fixtures
    {
        public Fixtures(Background background)
        {
            MainWindow.Calendar.Background = background.GetBackground();
        }
    }
